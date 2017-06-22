using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.Issuer;
using Mollie.Net.Models.List;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class IssuerClient : ClientBase, IIssuerClient
    {
        public IssuerClient(string apiKey) : base(apiKey) { }

        public async Task<ListResponse<IssuerResponse>> GetIssuerListAsync(int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<IssuerResponse>>("issuers", offset, count).ConfigureAwait(false);
        }

        public async Task<IssuerResponse> GetIssuerAsync(string issuerId)
        {
            return await this.GetAsync<IssuerResponse>($"issuers/{issuerId}").ConfigureAwait(false);
        }
    }
}
