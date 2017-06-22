﻿using Mollie.Net.Clients.Base;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Subscription;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class SubscriptionClient : ClientBase, ISubscriptionClient
    {
        public SubscriptionClient(string apiKey) : base(apiKey) { }

        public async Task<ListResponse<SubscriptionResponse>> GetSubscriptionListAsync(string customerId, int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<SubscriptionResponse>>($"customers/{customerId}/subscriptions", offset, count).ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId)
        {
            return await this.GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request)
        {
            return await this.PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request).ConfigureAwait(false);
        }

        public async Task CancelSubscriptionAsync(string customerId, string subscriptionId)
        {
            await this.DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }
    }
}
