using System.Threading.Tasks;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription {
    public interface ISubscriptionStorageClient {
        Task Create(CreateSubscriptionModel model);
    }
}