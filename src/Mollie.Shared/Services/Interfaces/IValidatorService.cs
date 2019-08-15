using Mollie.Models.Url;

namespace Mollie.Services
{
    public interface IValidatorService
    {
        void ValidateUrlLink(UrlLink urlObject);
    }
}
