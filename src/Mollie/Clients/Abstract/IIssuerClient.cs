using System.Threading.Tasks;
using Mollie.Models.Issuer;
using Mollie.Models.List;

namespace Mollie.Abstract {
    public interface IIssuerClient {
        Task<IssuerResponse> GetIssuerAsync(string issuerId);
        Task<ListResponse<IssuerResponse>> GetIssuerListAsync(int? offset = default(int?), int? count = default(int?));
    }
}