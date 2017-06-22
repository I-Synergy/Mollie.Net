using Mollie.Net.Models.List;
using Mollie.Net.Models.Subscription;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface ISubscriptionClient
    {
        Task CancelSubscriptionAsync(string customerId, string subscriptionId);
        Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request);
        Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId);
        Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, int? offset = default(int?), int? count = default(int?));
    }
}
