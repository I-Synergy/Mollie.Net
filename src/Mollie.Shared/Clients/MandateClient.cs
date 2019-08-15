using System.Net.Http;
using System.Threading.Tasks;
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

        public Task<MandateResponse> GetMandateAsync(string customerId, string mandateId) =>
            GetAsync<MandateResponse>($"customers/{customerId}/mandates/{mandateId}");

        public Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<MandateResponse>>($"customers/{customerId}/mandates", from, limit);

        public Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request) =>
            PostAsync<MandateResponse>($"customers/{customerId}/mandates", request);

        public Task<ListResponse<MandateResponse>> GetMandateListAsync(UrlObjectLink<ListResponse<MandateResponse>> url) =>
            GetAsync(url);

        public Task<MandateResponse> GetMandateAsync(UrlObjectLink<MandateResponse> url) =>
            GetAsync(url);

        public Task RevokeMandateAsync(string customerId, string mandateId) =>
            DeleteAsync($"customers/{customerId}/mandates/{mandateId}");
    }
}