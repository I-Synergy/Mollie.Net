using System.Threading.Tasks;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface ICustomerClient
    {
        Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request);
        Task<CustomerResponse> UpdateCustomerAsync(string customerId, CustomerRequest request);
        Task DeleteCustomerAsync(string customerId);
        Task<CustomerResponse> GetCustomerAsync(string customerId);
        Task<CustomerResponse> GetCustomerAsync(UrlObjectLink<CustomerResponse> url);
        Task<ListResponse<CustomerResponse>> GetCustomerListAsync(UrlObjectLink<ListResponse<CustomerResponse>> url);
        Task<ListResponse<CustomerResponse>> GetCustomerListAsync(string from = null, int? limit = null);
        Task<ListResponse<PaymentResponse>> GetCustomerPaymentListAsync(string customerId, string from = null, int? limit = null);
    }
}