using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Mandate;

namespace Mollie.Abstract {
    public interface IMandateClient {
        Task<MandateResponse> GetMandateAsync(string customerId, string mandateId);
        Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, int? offset = default(int?), int? count = default(int?));
        Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request);
    }
}