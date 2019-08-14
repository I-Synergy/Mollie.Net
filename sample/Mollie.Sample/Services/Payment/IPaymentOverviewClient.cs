using System.Threading.Tasks;
using Mollie.Models.Payment.Response;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Payment {
    public interface IPaymentOverviewClient {
        Task<OverviewModel<PaymentResponse>> GetList();
        Task<OverviewModel<PaymentResponse>> GetListByUrl(string url);
    }
}