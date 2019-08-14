using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Models.PaymentMethod;
using Mollie.Sample.Models;
using Mollie.Sample.Services.PaymentMethod;

namespace Mollie.Sample.Controllers {
    public class PaymentMethodController : Controller {
        private readonly IPaymentMethodOverviewClient _paymentMethodOverviewClient;

        public PaymentMethodController(IPaymentMethodOverviewClient paymentMethodOverviewClient) {
            this._paymentMethodOverviewClient = paymentMethodOverviewClient;
        }

        public async Task<ViewResult> Index() {
            OverviewModel<PaymentMethodResponse> model = await this._paymentMethodOverviewClient.GetList();
            return this.View(model);
        }
    }
}