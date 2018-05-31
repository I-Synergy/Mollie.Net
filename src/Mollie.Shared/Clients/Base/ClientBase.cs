using Mollie.Converters;
using Mollie.Exceptions;
using Mollie.Extensions;
using Mollie.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Clients.Base
{
    public abstract class ClientBase
    {
        protected const string ApiEndPoint = "https://api.mollie.com/v1/";

        protected readonly string _apiKey;
        protected readonly JsonSerializerSettings _defaultJsonDeserializerSettings;
        protected readonly HttpClient _client;

        protected ClientBase(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Mollie API key cannot be empty");

            _apiKey = apiKey;
            _defaultJsonDeserializerSettings = CreateDefaultJsonDeserializerSettings();
            _client = CreateHttpClient();
        }

        protected async Task<T> GetAsync<T>(string relativeUri)
        {
            return await ExecuteRequestAsync<T>(
                await _client.GetAsync(relativeUri).ConfigureAwait(false))
                    .ConfigureAwait(false);
        }
        
        protected async Task<T> GetListAsync<T>(string relativeUri, int? offset, int? count, IDictionary<string, object> otherParameters = null)
        {
            return await ExecuteRequestAsync<T>(
                await _client.GetAsync($"{relativeUri}{BuildListQueryString(offset, count, otherParameters)}").ConfigureAwait(false))
                    .ConfigureAwait(false);
        }

        protected async Task<T> PostAsync<T>(string relativeUri, object data)
        {
            return await ExecuteRequestAsync<T>(
                await _client.PostAsync(relativeUri, new StringContent(
                    JsonConvertExtensions.SerializeObjectCamelCase(data),
                    Encoding.UTF8, 
                    "application/json")))
                .ConfigureAwait(false);
        }

        protected async Task DeleteAsync(string relativeUri)
        {
            await ExecuteRequestAsync<object>(
                await _client.DeleteAsync(relativeUri).ConfigureAwait(false))
                    .ConfigureAwait(false);
        }

        private async Task<T> ExecuteRequestAsync<T>(HttpResponseMessage response)
        {
            var resultContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(resultContent, _defaultJsonDeserializerSettings);
            }
            else
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.Unauthorized:
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.NotFound:
                    case HttpStatusCode.MethodNotAllowed:
                    case HttpStatusCode.UnsupportedMediaType:
                    case (HttpStatusCode)422: // Unprocessable entity
                        throw new MollieException(resultContent);
                    default:
                        throw new HttpRequestException($"Unknown http exception occured with status code: {(int)response.StatusCode}.");
                }
            }
        }

        protected void ValidateApiKeyIsOauthAccesstoken(bool isConstructor = false)
        {
            if (!this._apiKey.StartsWith("live_") && !this._apiKey.StartsWith("test_"))
            {
                if (isConstructor)
                {
                    throw new InvalidOperationException(
                        "The provided token isn't an oauth token. You have invoked the method with oauth parameters thus an oauth accesstoken is required.");
                }
                throw new ArgumentException("The provided token isn't an oauth token.");
            }
        }

        private string BuildListQueryString(int? offset, int? count, IDictionary<string, object> otherParameters = null)
        {
            Dictionary<string, object> queryParameters = new Dictionary<string, object>();

            if (offset.HasValue)
            {
                queryParameters[nameof(offset)] = offset.Value.ToString();
            }

            if (count.HasValue)
            {
                queryParameters[nameof(count)] = count.Value.ToString();
            }

            if (otherParameters != null)
            {
                foreach (var parameter in otherParameters)
                {
                    queryParameters[parameter.Key] = parameter.Value;
                }
            }

            return queryParameters.ToQueryString();
        }

        private HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ApiEndPoint)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this._apiKey);

            return client;
        }

        private JsonSerializerSettings CreateDefaultJsonDeserializerSettings()
        {
            return new JsonSerializerSettings
            {
                DateFormatString = "MM-dd-yyyy",
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new List<JsonConverter> {
                    // Add a special converter for payment responses, because we need to create specific classes based on the payment method
                    new PaymentResponseConverter(new PaymentResponseFactory())
                }
            };
        }
    }
}
