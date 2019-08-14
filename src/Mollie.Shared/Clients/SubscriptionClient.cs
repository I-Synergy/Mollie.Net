using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<SubscriptionResponse>>($"customers/{customerId}/subscriptions", from, limit).ConfigureAwait(false);
        }

        public async Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(UrlObjectLink<ListResponse<SubscriptionResponse>> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> GetSubscriptionAsync(UrlObjectLink<SubscriptionResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId)
        {
            return await GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request)
        {
            return await PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request).ConfigureAwait(false);
        }

        public async Task CancelSubscriptionAsync(string customerId, string subscriptionId)
        {
            await DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> UpdateSubscriptionAsync(string customerId, string subscriptionId, SubscriptionUpdateRequest request)
        {
            return await PatchAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}", request).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetSubscriptionPaymentListAsync(string customerId, string subscriptionId, string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<PaymentResponse>>($"customers/{customerId}/subscriptions/{subscriptionId}/payments", from, limit).ConfigureAwait(false);
        }
    }
}