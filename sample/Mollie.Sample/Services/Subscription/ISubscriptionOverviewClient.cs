using System.Threading.Tasks;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Subscription {
    public interface ISubscriptionOverviewClient {
        Task<OverviewModel<SubscriptionResponse>> GetList(string customerId);
        Task<OverviewModel<SubscriptionResponse>> GetListByUrl(string url);
    }
}