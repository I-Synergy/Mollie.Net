using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.Customer;
using Mollie.Net.Models.List;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class CustomerClient : ClientBase, ICustomerClient
    {
        public CustomerClient(string apiKey) : base(apiKey) { }

        public async Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request)
        {
            return await this.PostAsync<CustomerResponse>($"customers", request).ConfigureAwait(false);
        }

        public async Task<CustomerResponse> GetCustomerAsync(string customerId)
        {
            return await this.GetAsync<CustomerResponse>($"customers/{customerId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<CustomerResponse>> GetCustomerListAsync(int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<CustomerResponse>>("customers", offset, count).ConfigureAwait(false);
        }
    }
}
