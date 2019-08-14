using System.Threading.Tasks;
using Mollie.Models.PaymentMethod;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.PaymentMethod {
    public interface IPaymentMethodOverviewClient {
        Task<OverviewModel<PaymentMethodResponse>> GetList();
    }
}