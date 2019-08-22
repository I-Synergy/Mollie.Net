using System.Threading.Tasks;
using Mollie.Client;
using Mollie.Models;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;

namespace Mollie.Sample.Services.Payment.Refund
{
    public interface IRefundPaymentClient {
        Task Refund(string paymentId);
    }

    public class RefundPaymentClient : IRefundPaymentClient {
        private readonly IRefundClient _refundClient;
        private readonly IPaymentClient _paymentClient;

        public RefundPaymentClient(IRefundClient refundClient, IPaymentClient paymentClient) {
            _refundClient = refundClient;
            _paymentClient = paymentClient;
        }

        public async Task Refund(string paymentId) {
            PaymentResponse paymentToRefund = await GetPaymentDetails(paymentId);
            RefundRequest refundRequest = new RefundRequest() {
                Amount = new Amount(paymentToRefund.Amount.Currency, paymentToRefund.Amount.Value)
            };

            await _refundClient.CreateRefundAsync(paymentId, refundRequest);
        }

        private async Task<PaymentResponse> GetPaymentDetails(string paymentId) {
            return await _paymentClient.GetPaymentAsync(paymentId);
        }
    }
}