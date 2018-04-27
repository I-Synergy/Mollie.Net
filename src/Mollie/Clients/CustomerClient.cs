using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class CustomerClient : ClientBase, ICustomerClient {
        public CustomerClient(string apiKey) : base(apiKey) {
        }

        public Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request) =>
            PostAsync<CustomerResponse>($"customers", request);

        public Task<CustomerResponse> GetCustomerAsync(string customerId) =>
            GetAsync<CustomerResponse>($"customers/{customerId}");

        public Task<ListResponse<CustomerResponse>> GetCustomerListAsync(int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<CustomerResponse>>("customers", offset, count);
    }
}