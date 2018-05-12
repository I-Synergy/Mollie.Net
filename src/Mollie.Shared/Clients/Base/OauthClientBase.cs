using Mollie.Clients.Base;
using System;

namespace Mollie.Client.Base {
    public class OAuthClientBase : ClientBase
    {
        public OAuthClientBase(string oauthAccessToken) : base(oauthAccessToken)
        {
            if (string.IsNullOrWhiteSpace(oauthAccessToken)) {
                throw new ArgumentNullException(nameof(oauthAccessToken), "Mollie API key cannot be empty");
            }

            this.ValidateApiKeyIsOauthAccesstoken(true);
        }
    }
}