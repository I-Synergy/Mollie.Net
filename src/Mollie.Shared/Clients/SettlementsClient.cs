using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<SettlementResponse> GetSettlementAsync(string settlementId)
        {
            return await GetAsync<SettlementResponse>($"settlements/{settlementId}").ConfigureAwait(false);
        }

        public async Task<SettlementResponse> GetNextSettlement()
        {
            return await GetAsync<SettlementResponse>($"settlements/next").ConfigureAwait(false);
        }

        public async Task<SettlementResponse> GetOpenBalance()
        {
            return await GetAsync<SettlementResponse>($"settlements/open").ConfigureAwait(false);
        }

        public async Task<ListResponse<SettlementResponse>> GetSettlementsListAsync(string reference = null, string offset = null, int? count = null)
        {
            var queryString = !string.IsNullOrWhiteSpace(reference) ? $"?reference={reference}" : string.Empty;
            return await GetListAsync<ListResponse<SettlementResponse>>($"settlements{queryString}", offset, count).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetSettlementPaymentsListAsync(string settlementId, string offset = null, int? count = null)
        {
            return await GetListAsync<ListResponse<PaymentResponse>>($"settlements/{settlementId}/payments", offset, count).ConfigureAwait(false);
        }

        public async Task<ListResponse<RefundResponse>> GetSettlementRefundsListAsync(string settlementId, string offset = null, int? count = null)
        {
            return await GetListAsync<ListResponse<RefundResponse>>($"settlements/{settlementId}/refunds", offset, count).ConfigureAwait(false);
        }

        public async Task<ListResponse<ChargebackResponse>> GetSettlementChargebacksListAsync(string settlementId, string offset = null, int? count = null)
        {
            return await GetListAsync<ListResponse<ChargebackResponse>>($"settlements/{settlementId}/chargebacks", offset, count).ConfigureAwait(false);
        }

        public async Task<SettlementResponse> GetSettlementAsync(UrlObjectLink<SettlementResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }
    }
}