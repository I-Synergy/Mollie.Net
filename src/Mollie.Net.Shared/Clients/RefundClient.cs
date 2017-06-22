using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Refund;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class RefundClient : ClientBase, IRefundClient
    {
        public RefundClient(string apiKey) : base(apiKey) { }

        public async Task<RefundResponse> CreateRefundAsync(string paymentId)
        {
            return await this.CreateRefundAsync(paymentId, new RefundRequest()).ConfigureAwait(false);
        }

        public async Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest)
        {
            return await this.PostAsync<RefundResponse>($"payments/{paymentId}/refunds", refundRequest).ConfigureAwait(false);
        }

        public async Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<RefundResponse>>($"payments/{paymentId}/refunds", offset, count).ConfigureAwait(false);
        }

        public async Task<RefundResponse> GetRefundAsync(string paymentId, string refundId)
        {
            return await this.GetAsync<RefundResponse>($"payments/{paymentId}/refunds/{refundId}").ConfigureAwait(false);
        }

        public async Task CancelRefundAsync(string paymentId, string refundId)
        {
            await this.DeleteAsync($"payments/{paymentId}/refunds/{refundId}").ConfigureAwait(false);
        }
    }
}
