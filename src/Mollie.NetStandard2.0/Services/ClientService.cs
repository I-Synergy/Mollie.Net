using Microsoft.Extensions.Options;
using Mollie.Client;
using Mollie.Converters;
using Mollie.Models;
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

        private AppSettings Settings { get; }
        private IHttpClientFactory HttpClientFactory { get; }
        private IJsonConverterService JsonConverterService { get; }
        private IValidatorService ValidatorService { get; }

        /// <summary>
        /// Create a new Service client
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="httpClientFactory"></param>
        /// <param name="jsonConverterService"></param>
        /// <param name="validatorService"></param>
        public ClientService(IOptions<AppSettings> settings, IHttpClientFactory httpClientFactory, IJsonConverterService jsonConverterService, IValidatorService validatorService)
        {
            Settings = settings.Value;
            ApiKey = Settings.ApiToken;

            HttpClientFactory = httpClientFactory;
            JsonConverterService = jsonConverterService;
            ValidatorService = validatorService;
        }

        public async Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string relativeUri, object data = null)
        {
            T result = default;

            HttpRequestMessage httpRequest = CreateHttpRequest(httpMethod, relativeUri);

            if (data != null)
            {
                var jsonData = JsonConverterService.Serialize(data);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                httpRequest.Content = content;
            }

            using (var httpClient = HttpClientFactory.CreateClient(Constants.HttpClientDefault))
            {
                using (var response = await httpClient.SendAsync(httpRequest))
                {
                    //Disable! otherwise HttpRequestException is thrown instead of MollieApiException
                    //response.EnsureSuccessStatusCode();
                    result = await ProcessHttpResponseMessageAsync<T>(response);
                }
            }

            return result;
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
            ValidatorService.ValidateUrlLink(urlObject);
            return GetAsync<T>(urlObject.Href);
        }

        public Task<T> PostAsync<T>(string relativeUri, object data) =>
            SendHttpRequestAsync<T>(HttpMethod.Post, relativeUri, data);

        public Task<T> PatchAsync<T>(string relativeUri, object data) =>
            SendHttpRequestAsync<T>(new HttpMethod("PATCH"), relativeUri, data);

        public Task DeleteAsync(string relativeUri, object data = null) =>
            SendHttpRequestAsync<object>(HttpMethod.Delete, relativeUri, data);

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, string relativeUri, HttpContent content = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, new Uri(new Uri(Constants.ApiEndpoint), relativeUri));
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", ApiKey);
            httpRequest.Content = content;

            return httpRequest;
        }

        private async Task<T> ProcessHttpResponseMessageAsync<T>(HttpResponseMessage response)
        {
            var resultContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConverterService.Deserialize<T>(resultContent);
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
    }
}
