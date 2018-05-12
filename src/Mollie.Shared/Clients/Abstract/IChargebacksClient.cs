using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;

namespace Mollie.Abstract {
    public interface IChargebacksClient {
        Task<ChargebackResponse> GetChargebackAsync(string paymentId, string chargebackId);
        Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string paymentId, int? offset = null, int? count = null);
        Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(int? offset = null, int? count = null, string oathProfileId = null, bool? oauthTestmode = null);
    }
}