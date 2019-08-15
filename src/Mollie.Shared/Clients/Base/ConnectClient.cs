﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mollie.ContractResolvers;
using Mollie.Converters;
using Mollie.Models.Connect;
using Newtonsoft.Json;

namespace Mollie.Client
{
    public class ConnectClient : IConnectClient
    {
        public const string AuthorizeEndPoint = "https://www.mollie.com/oauth2/authorize";
        public const string TokenEndPoint = "https://api.mollie.nl/oauth2/tokens";
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly HttpClient _httpClient;

        public ConnectClient(string clientId, string clientSecret, HttpClient httpClient = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            _httpClient = httpClient ?? new HttpClient();
            _clientSecret = clientSecret;
            _clientId = clientId;
        }

        public string GetAuthorizationUrl(string state, List<string> scopes, string redirectUri = null, bool forceApprovalPrompt = false)
        {
            var parameters = new Dictionary<string, string> {
                {"client_id", _clientId},
                {"state", state},
                {"scope", string.Join(" ", scopes)},
                {"response_type", "code"},
                {"approval_prompt", forceApprovalPrompt ? "force" : "auto"}
            };
            parameters.AddValueIfNotNullOrEmpty("redirect_uri", redirectUri);

            return AuthorizeEndPoint + parameters.ToQueryString();
        }

        public async Task<TokenResponse> GetAccessTokenAsync(TokenRequest request)
        {
            var jsonData = JsonConvertExtensions.SerializeObjectSnakeCase(request);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpRequestMessage httpRequest = CreateHttpRequest(HttpMethod.Post, TokenEndPoint, content);

            var response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            var resultContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TokenResponse>(resultContent, new JsonSerializerSettings { ContractResolver = new SnakeCasePropertyNamesContractResolver() });
        }

        private HttpRequestMessage CreateHttpRequest(HttpMethod method, string url, HttpContent content = null)
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(method, new Uri(url));
            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", Base64Encode($"{_clientId}:{_clientSecret}"));
            httpRequest.Content = content;

            return httpRequest;
        }

        private string Base64Encode(string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}