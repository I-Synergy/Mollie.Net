using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription
{
    public class SubscriptionStorageClient : ISubscriptionStorageClient {
        private readonly ISubscriptionClient _subscriptionClient;
        private readonly IMapper _mapper;

        public SubscriptionStorageClient(ISubscriptionClient subscriptionClient, IMapper mapper) {
            _subscriptionClient = subscriptionClient;
            _mapper = mapper;
        }

        public async Task Create(CreateSubscriptionModel model) {
            SubscriptionRequest subscriptionRequest = _mapper.Map<SubscriptionRequest>(model);
            await _subscriptionClient.CreateSubscriptionAsync(model.CustomerId, subscriptionRequest);
        }
    }
}