using System.Threading.Tasks;
using AutoMapper;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription
{
    public class SubscriptionStorageClient : ISubscriptionStorageClient {
        private readonly ISubscriptionClient _subscriptionClient;
        private readonly IMapper _mapper;

        public SubscriptionStorageClient(ISubscriptionClient subscriptionClient, IMapper mapper) {
            this._subscriptionClient = subscriptionClient;
            this._mapper = mapper;
        }

        public async Task Create(CreateSubscriptionModel model) {
            SubscriptionRequest subscriptionRequest = this._mapper.Map<SubscriptionRequest>(model);
            await this._subscriptionClient.CreateSubscriptionAsync(model.CustomerId, subscriptionRequest);
        }
    }
}