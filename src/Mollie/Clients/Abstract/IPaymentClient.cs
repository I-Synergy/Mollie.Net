using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;

namespace Mollie.Abstract {
    public interface IPaymentClient {
        Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest);
		Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false);
	    Task DeletePaymentAsync(string paymentId);
		Task<ListResponse<PaymentResponse>> GetPaymentListAsync(int? offset = null, int? count = null, string profileId = null, bool? testMode = null);
    }
}