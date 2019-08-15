using System;
using Mollie.Services;

namespace Mollie.Client
{
    public abstract class ClientBase
    {
        public IClientService ClientService { get; }

        protected ClientBase(IClientService clientService)
        {
            ClientService = clientService;
        }
        
        protected void ValidateApiKeyIsOauthAccesstoken(bool isConstructor = false)
        {
            if (!ClientService.ApiKey.StartsWith("access_"))
            {
                if (isConstructor)
                {
                    throw new InvalidOperationException(
                        "The provided token isn't an oauth token. You have invoked the method with oauth parameters thus an oauth accesstoken is required.");
                }

                throw new ArgumentException("The provided token isn't an oauth token.");
            }
        }
    }
}