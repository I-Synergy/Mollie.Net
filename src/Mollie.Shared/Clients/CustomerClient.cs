using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request)
        {
            return await PostAsync<CustomerResponse>($"customers", request).ConfigureAwait(false);
        }

        public async Task<CustomerResponse> UpdateCustomerAsync(string customerId, CustomerRequest request)
        {
            return await PostAsync<CustomerResponse>($"customers/{customerId}", request).ConfigureAwait(false);
        }

        public async Task DeleteCustomerAsync(string customerId)
        {
            await DeleteAsync($"customers/{customerId}").ConfigureAwait(false);
        }

        public async Task<CustomerResponse> GetCustomerAsync(string customerId)
        {
            return await GetAsync<CustomerResponse>($"customers/{customerId}").ConfigureAwait(false);
        }

        public async Task<CustomerResponse> GetCustomerAsync(UrlObjectLink<CustomerResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<ListResponse<CustomerResponse>> GetCustomerListAsync(UrlObjectLink<ListResponse<CustomerResponse>> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<ListResponse<CustomerResponse>> GetCustomerListAsync(string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<CustomerResponse>>("customers", from, limit)
                .ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetCustomerPaymentListAsync(string customerId, string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/payments", from, limit).ConfigureAwait(false);
        }
    }
}