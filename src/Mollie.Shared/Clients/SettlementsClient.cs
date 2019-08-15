using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Settlement;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class SettlementsClient : OauthClientBase, ISettlementsClient
    {
        public SettlementsClient(string oauthAccessToken, HttpClient httpClient = null) : base(oauthAccessToken, httpClient)
        {
        }

        public Task<SettlementResponse> GetSettlementAsync(string settlementId) =>
            GetAsync<SettlementResponse>($"settlements/{settlementId}");

        public Task<SettlementResponse> GetNextSettlementAsync() =>
            GetAsync<SettlementResponse>($"settlements/next");

        public Task<SettlementResponse> GetOpenBalanceAsync() =>
            GetAsync<SettlementResponse>($"settlements/open");

        public Task<ListResponse<SettlementResponse>> GetSettlementsListAsync(string reference = null, string offset = null, int? count = null)
        {
            var queryString = !string.IsNullOrWhiteSpace(reference) ? $"?reference={reference}" : string.Empty;
            return GetListAsync<ListResponse<SettlementResponse>>($"settlements{queryString}", offset, count);
        }

        public Task<ListResponse<PaymentResponse>> GetSettlementPaymentsListAsync(string settlementId, string offset = null, int? count = null) =>
            GetListAsync<ListResponse<PaymentResponse>>($"settlements/{settlementId}/payments", offset, count);

        public Task<ListResponse<RefundResponse>> GetSettlementRefundsListAsync(string settlementId, string offset = null, int? count = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"settlements/{settlementId}/refunds", offset, count);

        public Task<ListResponse<ChargebackResponse>> GetSettlementChargebacksListAsync(string settlementId, string offset = null, int? count = null) =>
            GetListAsync<ListResponse<ChargebackResponse>>($"settlements/{settlementId}/chargebacks", offset, count);

        public Task<SettlementResponse> GetSettlementAsync(UrlObjectLink<SettlementResponse> url) =>
            GetAsync(url);
    }
}