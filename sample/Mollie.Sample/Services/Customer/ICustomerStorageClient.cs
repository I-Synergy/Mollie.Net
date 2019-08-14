using System.Threading.Tasks;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Customer {
    public interface ICustomerStorageClient {
        Task Create(CreateCustomerModel model);
    }
}