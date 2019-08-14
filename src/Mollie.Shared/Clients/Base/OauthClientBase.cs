using System;
using System.Net.Http;

namespace Mollie.Client
{
    public class OauthClientBase : ClientBase
    {
        public OauthClientBase(string oauthAccessToken, HttpClient httpClient = null) : base(oauthAccessToken, httpClient)
        {
            if (string.IsNullOrWhiteSpace(oauthAccessToken))
            {
                throw new ArgumentNullException(nameof(oauthAccessToken), "Mollie API key cannot be empty");
            }

            ValidateApiKeyIsOauthAccesstoken(true);
        }
    }
}