using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Mandate;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class MandateClient : ClientBase, IMandateClient
    {
        public MandateClient(string apiKey) : base(apiKey) { }

        public async Task<MandateResponse> GetMandateAsync(string customerId, string mandateId)
        {
            return await this.GetAsync<MandateResponse>($"customers/{customerId}/mandates/{mandateId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<MandateResponse>>($"customers/{customerId}/mandates", offset, count).ConfigureAwait(false);
        }

        public async Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request)
        {
            return await this.PostAsync<MandateResponse>($"customers/{customerId}/mandates", request).ConfigureAwait(false);
        }
    }
}
