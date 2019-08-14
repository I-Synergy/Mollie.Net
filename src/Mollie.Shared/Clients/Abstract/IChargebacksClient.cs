using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;

namespace Mollie.Client.Abstract
{
    public interface IChargebacksClient
    {
        Task<ChargebackResponse> GetChargebackAsync(string paymentId, string chargebackId);
        Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string paymentId, string from = null, int? limit = null);
        Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string profileId = null, bool? testmode = null);
    }
}