using System.Threading.Tasks;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Payment {
    public interface IPaymentStorageClient {
        Task Create(CreatePaymentModel model);
    }
}