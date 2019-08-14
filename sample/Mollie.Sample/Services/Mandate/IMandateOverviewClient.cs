using System.Threading.Tasks;
using Mollie.Models.Mandate;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Mandate {
    public interface IMandateOverviewClient {
        Task<OverviewModel<MandateResponse>> GetList(string customerId);
        Task<OverviewModel<MandateResponse>> GetListByUrl(string url);
    }
}