using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class CustomerClient : ClientBase, ICustomerClient
    {
        public CustomerClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request) =>
            PostAsync<CustomerResponse>($"customers", request);

        public Task<CustomerResponse> UpdateCustomerAsync(string customerId, CustomerRequest request) =>
            PostAsync<CustomerResponse>($"customers/{customerId}", request);

        public Task DeleteCustomerAsync(string customerId) =>
            DeleteAsync($"customers/{customerId}");

        public Task<CustomerResponse> GetCustomerAsync(string customerId) =>
            GetAsync<CustomerResponse>($"customers/{customerId}");

        public Task<CustomerResponse> GetCustomerAsync(UrlObjectLink<CustomerResponse> url) =>
            GetAsync(url);

        public Task<ListResponse<CustomerResponse>> GetCustomerListAsync(UrlObjectLink<ListResponse<CustomerResponse>> url) =>
            GetAsync(url);

        public Task<ListResponse<CustomerResponse>> GetCustomerListAsync(string from = null, int? limit = null) =>
            GetListAsync<ListResponse<CustomerResponse>>("customers", from, limit);

        public Task<ListResponse<PaymentResponse>> GetCustomerPaymentListAsync(string customerId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/payments", from, limit);
    }
}