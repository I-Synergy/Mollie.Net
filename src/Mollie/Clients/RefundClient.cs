using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.List;
using Mollie.Models.Refund;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class RefundClient : ClientBase, IRefundClient {
        public RefundClient(string apiKey) : base(apiKey) {
        }

        public Task<RefundResponse> CreateRefundAsync(string paymentId) =>
            CreateRefundAsync(paymentId, new RefundRequest());

        public Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest) =>
            PostAsync<RefundResponse>($"payments/{paymentId}/refunds", refundRequest);

        public Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, int? offset = null,
            int? count = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"payments/{paymentId}/refunds", offset, count);

        public Task<RefundResponse> GetRefundAsync(string paymentId, string refundId) =>
            GetAsync<RefundResponse>($"payments/{paymentId}/refunds/{refundId}");

        public Task CancelRefundAsync(string paymentId, string refundId) =>
            DeleteAsync($"payments/{paymentId}/refunds/{refundId}");
    }
}