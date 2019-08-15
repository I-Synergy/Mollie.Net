using Mollie.Client;
using Mollie.Converters;
using Mollie.Models.Url;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Services
{
    public class ClientService : IClientService
    {
        public string ApiKey { get; }


        private readonly HttpClient _httpClient;
        private readonly JsonConverterService _jsonConverterService;
        private readonly IValidatorService _validatorService;

        public ClientService(string apiKey, HttpClient httpClient = null, IValidatorService validatorService = null)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "Mollie API key cannot be empty");
            }

            _jsonConverterService = new JsonConverterService();
            _httpClient = httpClient ?? new HttpClient();
            _validatorService = validatorService ?? new ValidatorService();

            ApiKey = apiKey;
        }

        public async Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string relativeUri, object data = null)
        {
            HttpRequestMessage httpRequest = CreateHttpRequest(httpMethod, relativeUri);

            if (data != null)
            {
                var jsonData = _jsonConverterService.Serialize(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                httpRequest.Content = content;
            }

            var response = await _httpClient.SendAsync(httpRequest);
            return await ProcessHttpResponseMessageAsync<T>(response);
        }

        public Task<T> GetListAsync<T>(string relativeUri, string from, int? limit, IDictionary<string, string> otherParameters = null)
        {
            string url = relativeUri + StringConverters.BuildListQueryString(from, limit, otherParameters);
            return SendHttpRequestAsync<T>(HttpMethod.Get, url);
        }

        public Task<T> GetAsync<T>(string relativeUri) =>
            SendHttpRequestAsync<T>(HttpMethod.Get, relativeUri);

        public Task<T> GetAsync<T>(UrlObjectLink<T> urlObject)
        {
            _validatorService.ValidateUrlLink(urlObject);
            return GetAsync<T>(urlObject.Href);
        }

        public Task<T> PostAsync<T>(string relativeUri, object data) =>
            SendHttpRequestAsync<T>(HttpMethod.Post, relativeUri, data);

        public Task<T> PatchAsync<T>(string relativeUri, object data) =>
            SendHttpRequestAsync<T>(new HttpMethod("PATCH"), relativeUri, data);

        public Task DeleteAsync(string relativeUri, object data = null) =>
            SendHttpRequestAsync<object>(HttpMethod.Delete, relativeUri, data);

        private async Task<T> ProcessHttpResponseMessageAsync<T>(HttpResponseMessage response)
        {
            var resultContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return _jsonConverterService.Deserialize<T>(resultContent);
            }

            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Unauthorized:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.NotFound:
                case HttpStatusCode.MethodNotAllowed:
                case HttpStatusCode.UnsupportedMediaType:
                case HttpStatusCode.Gone:
                case (HttpStatusCode)422: // Unprocessable entity
                    throw new MollieApiException(resultContent);
                default:
                    throw new HttpRequestException(
                        $"Unknown http exception occured with status code: {(int)response.StatusCode}.");
            }
        }

        protected void ValidateApiKeyIsOauthAccesstoken(bool isConstructor = false)
        {
            if (!ApiKey.StartsWith("access_"))
            {
                if (isConstructor)
                {
                    throw new InvalidOperationException(
                        "The provided token isn't an oauth token. You have invoked the method with oauth parameters thus an oauth accesstoken is required.");
                }

                throw new ArgumentException("The provided token isn't an oauth token.");
            }
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, string relativeUri, HttpContent content = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, new Uri(new Uri(Constants.ApiEndpoint), relativeUri));
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            httpRequest.Content = content;

            return httpRequest;
        }
    }
}
