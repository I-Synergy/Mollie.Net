using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<RefundResponse> CreateRefundAsync(string paymentId, RefundRequest refundRequest)
        {
            if (refundRequest.Testmode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            return await PostAsync<RefundResponse>($"payments/{paymentId}/refunds", refundRequest).ConfigureAwait(false);
        }

        public async Task<ListResponse<RefundResponse>> GetRefundListAsync(string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<RefundResponse>>($"refunds", from, limit).ConfigureAwait(false);
        }

        public async Task<ListResponse<RefundResponse>> GetRefundListAsync(string paymentId, string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<RefundResponse>>($"payments/{paymentId}/refunds", from, limit).ConfigureAwait(false);
        }

        public async Task<RefundResponse> GetRefundAsync(UrlObjectLink<RefundResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<RefundResponse> GetRefundAsync(string paymentId, string refundId)
        {
            return await GetAsync<RefundResponse>($"payments/{paymentId}/refunds/{refundId}").ConfigureAwait(false);
        }

        public async Task CancelRefundAsync(string paymentId, string refundId)
        {
            await DeleteAsync($"payments/{paymentId}/refunds/{refundId}").ConfigureAwait(false);
        }
    }
}