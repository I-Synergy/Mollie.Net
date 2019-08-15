using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Settlement;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class SettlementsClient : OauthClientBase, ISettlementsClient
    {
        public SettlementsClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<SettlementResponse> GetSettlementAsync(string settlementId) =>
            ClientService.GetAsync<SettlementResponse>($"settlements/{settlementId}");

        public Task<SettlementResponse> GetNextSettlementAsync() =>
            ClientService.GetAsync<SettlementResponse>($"settlements/next");

        public Task<SettlementResponse> GetOpenBalanceAsync() =>
            ClientService.GetAsync<SettlementResponse>($"settlements/open");

        public Task<ListResponse<SettlementResponse>> GetSettlementsListAsync(string reference = null, string offset = null, int? count = null)
        {
            var queryString = !string.IsNullOrWhiteSpace(reference) ? $"?reference={reference}" : string.Empty;
            return ClientService.GetListAsync<ListResponse<SettlementResponse>>($"settlements{queryString}", offset, count);
        }

        public Task<ListResponse<PaymentResponse>> GetSettlementPaymentsListAsync(string settlementId, string offset = null, int? count = null) =>
            ClientService.GetListAsync<ListResponse<PaymentResponse>>($"settlements/{settlementId}/payments", offset, count);

        public Task<ListResponse<RefundResponse>> GetSettlementRefundsListAsync(string settlementId, string offset = null, int? count = null) =>
            ClientService.GetListAsync<ListResponse<RefundResponse>>($"settlements/{settlementId}/refunds", offset, count);

        public Task<ListResponse<ChargebackResponse>> GetSettlementChargebacksListAsync(string settlementId, string offset = null, int? count = null) =>
            ClientService.GetListAsync<ListResponse<ChargebackResponse>>($"settlements/{settlementId}/chargebacks", offset, count);

        public Task<SettlementResponse> GetSettlementAsync(UrlObjectLink<SettlementResponse> url) =>
            ClientService.GetAsync(url);
    }
}