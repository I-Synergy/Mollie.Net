using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class MandateClient : ClientBase, IMandateClient
    {
        public MandateClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<MandateResponse> GetMandateAsync(string customerId, string mandateId)
        {
            return await GetAsync<MandateResponse>($"customers/{customerId}/mandates/{mandateId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, string from = null, int? limit = null)
        {
            return await
                GetListAsync<ListResponse<MandateResponse>>($"customers/{customerId}/mandates", from, limit).ConfigureAwait(false);
        }

        public async Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request)
        {
            return await PostAsync<MandateResponse>($"customers/{customerId}/mandates", request).ConfigureAwait(false);
        }

        public async Task<ListResponse<MandateResponse>> GetMandateListAsync(UrlObjectLink<ListResponse<MandateResponse>> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<MandateResponse> GetMandateAsync(UrlObjectLink<MandateResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task RevokeMandate(string customerId, string mandateId)
        {
            await DeleteAsync($"customers/{customerId}/mandates/{mandateId}").ConfigureAwait(false);
        }
    }
}