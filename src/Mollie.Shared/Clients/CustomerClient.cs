using System.Threading.Tasks;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class CustomerClient : ClientBase, ICustomerClient
    {
        public CustomerClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request) =>
            ClientService.PostAsync<CustomerResponse>($"customers", request);

        public Task<CustomerResponse> UpdateCustomerAsync(string customerId, CustomerRequest request) =>
            ClientService.PostAsync<CustomerResponse>($"customers/{customerId}", request);

        public Task DeleteCustomerAsync(string customerId) =>
            ClientService.DeleteAsync($"customers/{customerId}");

        public Task<CustomerResponse> GetCustomerAsync(string customerId) =>
            ClientService.GetAsync<CustomerResponse>($"customers/{customerId}");

        public Task<CustomerResponse> GetCustomerAsync(UrlObjectLink<CustomerResponse> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<CustomerResponse>> GetCustomerListAsync(UrlObjectLink<ListResponse<CustomerResponse>> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<CustomerResponse>> GetCustomerListAsync(string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<CustomerResponse>>("customers", from, limit);

        public Task<ListResponse<PaymentResponse>> GetCustomerPaymentListAsync(string customerId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/payments", from, limit);
    }
}