using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.List;
using Mollie.Models.Subscription;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class SubscriptionClient : ClientBase, ISubscriptionClient {
        public SubscriptionClient(string apiKey) : base(apiKey) {
        }

        public Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId,
            int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<SubscriptionResponse>>($"customers/{customerId}/subscriptions",
                offset, count);

        public Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId) =>
            GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}");

        public Task<SubscriptionResponse>
            CreateSubscriptionAsync(string customerId, SubscriptionRequest request) =>
            PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request);

        public Task CancelSubscriptionAsync(string customerId, string subscriptionId) =>
            DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}");
    }
}