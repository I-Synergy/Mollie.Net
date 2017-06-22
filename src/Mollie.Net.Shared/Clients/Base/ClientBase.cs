using Flurl;
using Flurl.Http;
using Mollie.Net.Converters;
using Mollie.Net.Exceptions;
using Mollie.Net.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mollie.Net.Clients.Base
{
    public abstract partial class ClientBase
    {
        public const string ApiEndPoint = "https://api.mollie.nl";
        public const string ApiVersion = "v1";

        private readonly string _apiKey;
        private readonly IFlurlClient _restClient;

        protected ClientBase(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Mollie API key cannot be empty");
            }

            this._apiKey = apiKey;
            this._restClient = new FlurlClient();
        }

        protected async Task<T> GetAsync<T>(string relativeUri)
        {
            return await new Url(ApiEndPoint)
                .AppendPathSegments(ApiVersion, relativeUri)
                .WithClient(_restClient)
                .WithOAuthBearerToken(_apiKey)
                .GetJsonAsync<T>();
        }

        protected async Task<T> GetListAsync<T>(string relativeUri, int? offset, int? count)
        {

            return await new Url(ApiEndPoint)
                .AppendPathSegments(ApiVersion, relativeUri)
                .SetQueryParams(new
                    {
                        offset = offset,
                        count = count
                    },  
                    Flurl.NullValueHandling.Remove)
                .WithClient(_restClient)
                .WithOAuthBearerToken(_apiKey)
                .GetJsonAsync<T>();
        }

        protected async Task<T> PostAsync<T>(string relativeUri, object data)
        {
            return await new Url(ApiEndPoint)
                    .AppendPathSegments(ApiVersion, relativeUri)
                    .WithClient(_restClient)
                    .WithOAuthBearerToken(_apiKey)
                    .PostStringAsync(JsonConvertExtensions.SerializeObjectCamelCase(data))
                    .ReceiveJson<T>();
        }

        private Task<T> ExecuteRequestAsync<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return Task.FromResult(
                    JsonConvert.DeserializeObject<T>(response.Content.ToString())
                    );
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
                        throw new MollieApiException(response.ReasonPhrase);
                    default:
                        throw new HttpRequestException($"Unknown http exception occured with status code: {(int)response.StatusCode}.");
                }
            }
        }

        protected async Task DeleteAsync(string relativeUri)
        {
            await new Url(ApiEndPoint)
                .AppendPathSegments(ApiVersion, relativeUri)
                .WithClient(_restClient)
                .WithOAuthBearerToken(_apiKey)
                .DeleteAsync();
        }
    }
}
