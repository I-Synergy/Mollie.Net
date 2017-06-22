using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Payment.Request;
using Mollie.Net.Models.Payment.Response;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class PaymentClient : ClientBase, IPaymentClient
    {
        public PaymentClient(string apiKey) : base(apiKey) { }

        public async Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            return await this.PostAsync<PaymentResponse>("payments", paymentRequest).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetPaymentListAsync(int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<PaymentResponse>>("payments", offset, count).ConfigureAwait(false);
        }

        public async Task<PaymentResponse> GetPaymentAsync(string paymentId)
        {
            return await this.GetAsync<PaymentResponse>($"payments/{paymentId}").ConfigureAwait(false);
        }
    }
}
