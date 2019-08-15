using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Refund;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class RefundClient : ClientBase, IRefundClient
    {
        public RefundClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest)
        {
            if (refundRequest.Testmode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            return PostAsync<RefundResponse>($"payments/{paymentId}/refunds", refundRequest);
        }

        public Task<ListResponse<RefundResponse>> GetRefundListAsync(string from = null, int? limit = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"refunds", from, limit);

        public Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"payments/{paymentId}/refunds", from, limit);

        public Task<RefundResponse> GetRefundAsync(UrlObjectLink<RefundResponse> url) =>
            GetAsync(url);

        public Task<RefundResponse> GetRefundAsync(string paymentId, string refundId) =>
            GetAsync<RefundResponse>($"payments/{paymentId}/refunds/{refundId}");

        public Task CancelRefundAsync(string paymentId, string refundId) =>
            DeleteAsync($"payments/{paymentId}/refunds/{refundId}");
    }
}