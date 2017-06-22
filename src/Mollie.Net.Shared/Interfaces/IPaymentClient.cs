using Mollie.Net.Models.List;
using Mollie.Net.Models.Payment.Request;
using Mollie.Net.Models.Payment.Response;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface IPaymentClient
    {
        Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest);
        Task<PaymentResponse> GetPaymentAsync(string paymentId);
        Task<ListResponse<PaymentResponse>> GetPaymentListAsync(int? offset = default(int?), int? count = default(int?));
    }
}
