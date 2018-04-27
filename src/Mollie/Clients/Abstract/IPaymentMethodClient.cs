using System.Threading.Tasks;
using Mollie.Enumerations;
using Mollie.Models.List;
using Mollie.Models.PaymentMethod;

namespace Mollie.Abstract {
    public interface IPaymentMethodClient {
        Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethods paymentMethod);
        Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(int? offset = default(int?), int? count = default(int?));
    }
}