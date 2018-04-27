using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.Issuer;
using Mollie.Models.List;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class IssuerClient : ClientBase, IIssuerClient {
        public IssuerClient(string apiKey) : base(apiKey) {
        }

        public Task<ListResponse<IssuerResponse>> GetIssuerListAsync(int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<IssuerResponse>>("issuers", offset, count);

        public Task<IssuerResponse> GetIssuerAsync(string issuerId) =>
            GetAsync<IssuerResponse>($"issuers/{issuerId}");
    }
}