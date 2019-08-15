﻿using System.Threading.Tasks;
using AutoMapper;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription
{
    public class SubscriptionOverviewClient : OverviewClientBase<SubscriptionResponse>, ISubscriptionOverviewClient {
        private readonly ISubscriptionClient _subscriptionClient;

        public SubscriptionOverviewClient(IMapper mapper, ISubscriptionClient subscriptionClient) : base(mapper) {
            this._subscriptionClient = subscriptionClient;
        }

        public async Task<OverviewModel<SubscriptionResponse>> GetList(string customerId) {
            return this.Map(await this._subscriptionClient.GetSubscriptionListAsync(customerId));
        }

        public async Task<OverviewModel<SubscriptionResponse>> GetListByUrl(string url) {
            return this.Map(await this._subscriptionClient.GetSubscriptionListAsync(this.CreateUrlObject(url)));
        }
    }
}