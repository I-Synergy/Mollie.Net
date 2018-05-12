using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Models.Settlement;

namespace Mollie.Abstract {
    public interface ISettlementsClient {
        Task<SettlementResponse> GetSettlementAsync(string settlementId);
        Task<SettlementResponse> GetNextSettlement();
        Task<SettlementResponse> GetOpenBalance();
        Task<ListResponse<SettlementResponse>> GetSettlementsListAsync(string reference = null, int? offset = null, int? count = null);
        Task<ListResponse<PaymentResponse>> GetSettlementPaymentsListAsync(string settlementId, int? offset = null, int? count = null);
        Task<ListResponse<RefundResponse>> GetSettlementRefundsListAsync(string settlementId, int? offset = null, int? count = null);
        Task<ListResponse<ChargebackResponse>> GetSettlementChargebacksListAsync(string settlementId, int? offset = null, int? count = null);
    }
}