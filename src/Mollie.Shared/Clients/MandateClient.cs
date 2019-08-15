using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class MandateClient : ClientBase, IMandateClient
    {
        public MandateClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<MandateResponse> GetMandateAsync(string customerId, string mandateId) =>
            ClientService.GetAsync<MandateResponse>($"customers/{customerId}/mandates/{mandateId}");

        public Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<MandateResponse>>($"customers/{customerId}/mandates", from, limit);

        public Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request) =>
            ClientService.PostAsync<MandateResponse>($"customers/{customerId}/mandates", request);

        public Task<ListResponse<MandateResponse>> GetMandateListAsync(UrlObjectLink<ListResponse<MandateResponse>> url) =>
            ClientService.GetAsync(url);

        public Task<MandateResponse> GetMandateAsync(UrlObjectLink<MandateResponse> url) =>
            ClientService.GetAsync(url);

        public Task RevokeMandateAsync(string customerId, string mandateId) =>
            ClientService.DeleteAsync($"customers/{customerId}/mandates/{mandateId}");
    }
}