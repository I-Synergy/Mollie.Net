using System.Threading.Tasks;
using Mollie.Enumerations;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.PaymentMethod;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public interface IPaymentMethodClient
    {
        Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethods paymentMethod, bool? includeIssuers = null, string locale = null, bool? includePricing = null, string profileId = null, bool? testmode = null);
        Task<ListResponse<PaymentMethodResponse>> GetAllPaymentMethodListAsync(string locale = null, bool? includeIssuers = null, bool? includePricing = null);
        Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(SequenceType? sequenceType = null, string locale = null, Amount amount = null, bool? includeIssuers = null, bool? includePricing = null, string profileId = null, bool? testmode = null, Resource? resource = null);
        Task<PaymentMethodResponse> GetPaymentMethodAsync(UrlObjectLink<PaymentMethodResponse> url);
    }
}