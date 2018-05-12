using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class MandateClient : ClientBase, IMandateClient {
        public MandateClient(string apiKey) : base(apiKey) {
        }

        public Task<MandateResponse> GetMandateAsync(string customerId, string mandateId) =>
            GetAsync<MandateResponse>($"customers/{customerId}/mandates/{mandateId}");

        public Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, int? offset = null,
            int? count = null) =>
            GetListAsync<ListResponse<MandateResponse>>($"customers/{customerId}/mandates", offset, count);

        public Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request) =>
            PostAsync<MandateResponse>($"customers/{customerId}/mandates", request);

        public Task RevokeMandate(string customerId, string mandateId) =>
            DeleteAsync($"customers/{customerId}/mandates/{mandateId}");
    }
}