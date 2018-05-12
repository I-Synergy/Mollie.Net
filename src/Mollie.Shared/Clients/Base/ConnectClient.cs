﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.ContractResolvers;
using Mollie.Extensions;
using Mollie.Models.Connect;
using Newtonsoft.Json;
using Mollie.Converters;

namespace Mollie.Client {
    public class ConnectClient : IConnectClient {
        public const string AuthorizeEndPoint = "https://www.mollie.com/oauth2/authorize";
        public const string TokenEndPoint = "https://api.mollie.com/oauth2/tokens";
        private readonly string _clientId;
        private readonly HttpClient _httpClient;

        public ConnectClient(string clientId, string clientSecret) {
            if (string.IsNullOrWhiteSpace(clientId)) {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(clientSecret)) {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            this._clientId = clientId;
            this._httpClient = this.CreateHttpClient(clientId, clientSecret);
        }

        public string GetAuthorizationUrl(string state, List<string> scopes, string redirectUri = null,
            bool forceApprovalPrompt = false) {
            var parameters = new Dictionary<string, object> {
                {"client_id", this._clientId},
                {"state", state},
                {"scope", string.Join(" ", scopes)},
                {"response_type", "code"},
                {"approval_prompt", forceApprovalPrompt ? "force" : "auto"}
            };

            if (!string.IsNullOrWhiteSpace(redirectUri)) {
                parameters.Add("redirect_uri", redirectUri);
            }

            return AuthorizeEndPoint + parameters.ToQueryString();
        }

        public async Task<TokenResponse> GetAccessTokenAsync(TokenRequest request) {
            var jsonData = JsonConvertExtensions.SerializeObjectSnakeCase(request);

            var response = await this._httpClient
                .PostAsync(TokenEndPoint, new StringContent(jsonData, Encoding.UTF8, "application/json"))
                .ConfigureAwait(false);
            var resultContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TokenResponse>(resultContent, new JsonSerializerSettings {ContractResolver = new SnakeCasePropertyNamesContractResolver()});
        }

        /// <summary>
        ///     Creates a new rest client for the Mollie API with basic authentication
        /// </summary>
        private HttpClient CreateHttpClient(string clientId, string clientSecret) {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.Base64Encode($"{clientId}:{clientSecret}"));
            return httpClient;
        }

        private string Base64Encode(string value) {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
    }
}