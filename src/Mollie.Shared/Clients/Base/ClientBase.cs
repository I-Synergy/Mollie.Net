﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public abstract class ClientBase
    {
        public const string ApiEndPoint = "https://api.mollie.com/v2/";

        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly JsonConverterService _jsonConverterService;

        protected ClientBase(string apiKey, HttpClient httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey), "Mollie API key cannot be empty");
            }

            _jsonConverterService = new JsonConverterService();
            _httpClient = httpClient ?? new HttpClient();
            _apiKey = apiKey;
        }

        private async Task<T> SendHttpRequest<T>(HttpMethod httpMethod, string relativeUri, object data = null)
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

        protected Task<T> GetListAsync<T>(string relativeUri, string from, int? limit, IDictionary<string, string> otherParameters = null)
        {
            string url = relativeUri + BuildListQueryString(from, limit, otherParameters);
            return SendHttpRequest<T>(HttpMethod.Get, url);
        }

        protected Task<T> GetAsync<T>(string relativeUri) =>
            SendHttpRequest<T>(HttpMethod.Get, relativeUri);

        protected Task<T> GetAsync<T>(UrlObjectLink<T> urlObject)
        {
            ValidateUrlLink(urlObject);
            return GetAsync<T>(urlObject.Href);
        }

        protected Task<T> PostAsync<T>(string relativeUri, object data) =>
            SendHttpRequest<T>(HttpMethod.Post, relativeUri, data);

        protected Task<T> PatchAsync<T>(string relativeUri, object data) =>
            SendHttpRequest<T>(new HttpMethod("PATCH"), relativeUri, data);

        protected Task DeleteAsync(string relativeUri, object data = null) =>
            SendHttpRequest<object>(HttpMethod.Delete, relativeUri, data);

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
            if (!_apiKey.StartsWith("access_"))
            {
                if (isConstructor)
                {
                    throw new InvalidOperationException(
                        "The provided token isn't an oauth token. You have invoked the method with oauth parameters thus an oauth accesstoken is required.");
                }

                throw new ArgumentException("The provided token isn't an oauth token.");
            }
        }

        private void ValidateUrlLink(UrlLink urlObject)
        {
            // Make sure the URL is not empty
            if (String.IsNullOrEmpty(urlObject?.Href))
            {
                throw new ArgumentException($"Url object is null or href is empty: {urlObject}");
            }

            // Don't execute any requests that don't point to the Mollie API URL for security reasons
            if (!urlObject.Href.Contains(ApiEndPoint))
            {
                throw new ArgumentException($"Url does not point to the Mollie API: {urlObject.Href}");
            }
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, string relativeUri, HttpContent content = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, new Uri(new Uri(ApiEndPoint), relativeUri));
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            httpRequest.Content = content;

            return httpRequest;
        }

        private string BuildListQueryString(string from, int? limit, IDictionary<string, string> otherParameters = null)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.AddValueIfNotNullOrEmpty(nameof(from), from);
            queryParameters.AddValueIfNotNullOrEmpty(nameof(limit), Convert.ToString(limit));

            if (otherParameters != null)
            {
                foreach (var parameter in otherParameters)
                {
                    queryParameters.AddValueIfNotNullOrEmpty(parameter.Key, parameter.Value);
                }
            }

            return queryParameters.ToQueryString();
        }
    }
}