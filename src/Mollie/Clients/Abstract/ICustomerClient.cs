using System.Threading.Tasks;
using Mollie.Models.Customer;
using Mollie.Models.List;

namespace Mollie.Abstract {
    public interface ICustomerClient {
        Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request);
        Task<CustomerResponse> GetCustomerAsync(string customerId);
        Task<ListResponse<CustomerResponse>> GetCustomerListAsync(int? offset = default(int?), int? count = default(int?));
    }
}