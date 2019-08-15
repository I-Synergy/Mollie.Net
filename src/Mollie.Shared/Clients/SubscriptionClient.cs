using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Payment.Response;
using Mollie.Models.Subscription;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class SubscriptionClient : ClientBase, ISubscriptionClient
    {
        public SubscriptionClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<SubscriptionResponse>>($"customers/{customerId}/subscriptions", from, limit);

        public Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(UrlObjectLink<ListResponse<SubscriptionResponse>> url) =>
            ClientService.GetAsync(url);

        public Task<SubscriptionResponse> GetSubscriptionAsync(UrlObjectLink<SubscriptionResponse> url) =>
            ClientService.GetAsync(url);

        public Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId) =>
            ClientService.GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}");

        public Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request) =>
            ClientService.PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request);

        public Task CancelSubscriptionAsync(string customerId, string subscriptionId) =>
            ClientService.DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}");

        public Task<SubscriptionResponse> UpdateSubscriptionAsync(string customerId, string subscriptionId, SubscriptionUpdateRequest request) =>
            ClientService.PatchAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}", request);

        public Task<ListResponse<PaymentResponse>> GetSubscriptionPaymentListAsync(string customerId, string subscriptionId, string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/subscriptions/{subscriptionId}/payments", from, limit);
    }
}