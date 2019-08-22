using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription
{
    public class SubscriptionOverviewClient : OverviewClientBase<SubscriptionResponse>, ISubscriptionOverviewClient {
        private readonly ISubscriptionClient _subscriptionClient;

        public SubscriptionOverviewClient(IMapper mapper, ISubscriptionClient subscriptionClient) : base(mapper) {
            _subscriptionClient = subscriptionClient;
        }

        public async Task<OverviewModel<SubscriptionResponse>> GetList(string customerId) {
            return Map(await _subscriptionClient.GetSubscriptionListAsync(customerId));
        }

        public async Task<OverviewModel<SubscriptionResponse>> GetListByUrl(string url) {
            return Map(await _subscriptionClient.GetSubscriptionListAsync(CreateUrlObject(url)));
        }
    }
}