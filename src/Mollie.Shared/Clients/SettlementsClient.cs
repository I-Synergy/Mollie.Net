using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Settlement;
using Mollie.Client.Base;

namespace Mollie.Client {
    public class SettlementsClient : OAuthClientBase, ISettlementsClient {
        public SettlementsClient(string oauthAccessToken) : base(oauthAccessToken) {
        }

        public Task<SettlementResponse> GetSettlementAsync(string settlementId) =>
            GetAsync<SettlementResponse>($"settlements/{settlementId}");

        public Task<SettlementResponse> GetNextSettlement() =>
            GetAsync<SettlementResponse>($"settlements/next");

        public Task<SettlementResponse> GetOpenBalance() =>
            GetAsync<SettlementResponse>($"settlements/open");

        public Task<ListResponse<SettlementResponse>> GetSettlementsListAsync(string reference = null,
            int? offset = null, int? count = null)
        {
            var queryString = !string.IsNullOrWhiteSpace(reference) ? $"?reference={reference}" : string.Empty;
            return GetListAsync<ListResponse<SettlementResponse>>($"settlements{queryString}", offset, count);
        }

        public Task<ListResponse<PaymentResponse>> GetSettlementPaymentsListAsync(string settlementId,
            int? offset = null, int? count = null) => 
            GetListAsync<ListResponse<PaymentResponse>>($"settlements/{settlementId}/payments", offset, count);

        public Task<ListResponse<RefundResponse>> GetSettlementRefundsListAsync(string settlementId,
            int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<RefundResponse>>($"settlements/{settlementId}/refunds", offset, count);

        public Task<ListResponse<ChargebackResponse>> GetSettlementChargebacksListAsync(string settlementId,
            int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<ChargebackResponse>>($"settlements/{settlementId}/chargebacks", offset,
                    count);
    }
}