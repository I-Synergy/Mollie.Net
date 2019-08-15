using Mollie.Services;
using System;

namespace Mollie.Client
{
    public class OauthClientBase : ClientBase
    {
        public OauthClientBase(IClientService clientService) : base(clientService)
        {
            if (string.IsNullOrWhiteSpace(ClientService.ApiKey))
            {
                throw new ArgumentNullException(nameof(ClientService.ApiKey), "Mollie API key cannot be empty");
            }

            ValidateApiKeyIsOauthAccesstoken(true);
        }
    }
}