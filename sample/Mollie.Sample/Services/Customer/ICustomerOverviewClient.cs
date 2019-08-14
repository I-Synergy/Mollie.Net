using System.Threading.Tasks;
using Mollie.Models.Customer;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Customer {
    public interface ICustomerOverviewClient {
        Task<OverviewModel<CustomerResponse>> GetList();
        Task<OverviewModel<CustomerResponse>> GetListByUrl(string url);
    }
}