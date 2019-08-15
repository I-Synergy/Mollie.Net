using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Refund;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class RefundClient : ClientBase, IRefundClient
    {
        public RefundClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest)
        {
            if (refundRequest.Testmode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            return ClientService.PostAsync<RefundResponse>($"payments/{paymentId}/refunds", refundRequest);
        }

        public Task<ListResponse<RefundResponse>> GetRefundListAsync(string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<RefundResponse>>($"refunds", from, limit);

        public Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<RefundResponse>>($"payments/{paymentId}/refunds", from, limit);

        public Task<RefundResponse> GetRefundAsync(UrlObjectLink<RefundResponse> url) =>
            ClientService.GetAsync(url);

        public Task<RefundResponse> GetRefundAsync(string paymentId, string refundId) =>
            ClientService.GetAsync<RefundResponse>($"payments/{paymentId}/refunds/{refundId}");

        public Task CancelRefundAsync(string paymentId, string refundId) =>
            ClientService.DeleteAsync($"payments/{paymentId}/refunds/{refundId}");
    }
}