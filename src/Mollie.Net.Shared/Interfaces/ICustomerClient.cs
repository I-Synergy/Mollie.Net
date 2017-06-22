using Mollie.Net.Models.Customer;
using Mollie.Net.Models.List;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface ICustomerClient
    {
        Task<CustomerResponse> CreateCustomerAsync(CustomerRequest request);
        Task<CustomerResponse> GetCustomerAsync(string customerId);
        Task<ListResponse<CustomerResponse>> GetCustomerListAsync(int? offset = default(int?), int? count = default(int?));
    }
}
