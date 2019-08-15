using Mollie.Models.Url;
using System;

namespace Mollie.Services
{
    public class ValidatorService : IValidatorService
    {
        public void ValidateUrlLink(UrlLink urlObject)
        {
            // Make sure the URL is not empty
            if (string.IsNullOrEmpty(urlObject?.Href))
            {
                throw new ArgumentException($"Url object is null or href is empty: {urlObject}");
            }

            // Don't execute any requests that don't point to the Mollie API URL for security reasons
            if (!urlObject.Href.Contains(Constants.ApiEndpoint))
            {
                throw new ArgumentException($"Url does not point to the Mollie API: {urlObject.Href}");
            }
        }
    }
}
