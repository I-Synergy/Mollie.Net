using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Subscription;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class SubscriptionClient : ClientBase, ISubscriptionClient
    {
        public SubscriptionClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<SubscriptionResponse>>($"customers/{customerId}/subscriptions", from, limit);

        public Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(UrlObjectLink<ListResponse<SubscriptionResponse>> url) =>
            GetAsync(url);

        public Task<SubscriptionResponse> GetSubscriptionAsync(UrlObjectLink<SubscriptionResponse> url) =>
            GetAsync(url);

        public Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId) =>
            GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}");

        public Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request) =>
            PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request);

        public Task CancelSubscriptionAsync(string customerId, string subscriptionId) =>
            DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}");

        public Task<SubscriptionResponse> UpdateSubscriptionAsync(string customerId, string subscriptionId, SubscriptionUpdateRequest request) =>
            PatchAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}", request);

        public Task<ListResponse<PaymentResponse>> GetSubscriptionPaymentListAsync(string customerId, string subscriptionId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/subscriptions/{subscriptionId}/payments", from, limit);
    }
}