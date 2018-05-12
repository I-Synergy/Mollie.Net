using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Subscription;

namespace Mollie.Abstract {
    public interface ISubscriptionClient {
        Task CancelSubscriptionAsync(string customerId, string subscriptionId);
        Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request);
        Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId);
        Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, int? offset = default(int?), int? count = default(int?));
    }
}