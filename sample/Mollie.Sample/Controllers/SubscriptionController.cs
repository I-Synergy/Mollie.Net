using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Models;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;
using Mollie.Sample.Services.Subscription;

namespace Mollie.Sample.Controllers {
    public class SubscriptionController : Controller {
        private readonly ISubscriptionOverviewClient _subscriptionOverviewClient;
        private readonly ISubscriptionStorageClient _subscriptionStorageClient;

        public SubscriptionController(ISubscriptionOverviewClient subscriptionOverviewClient, ISubscriptionStorageClient subscriptionStorageClient) {
            _subscriptionOverviewClient = subscriptionOverviewClient;
            _subscriptionStorageClient = subscriptionStorageClient;
        }

        [HttpGet]
        public async Task<ViewResult> Index(string customerId) {
            ViewBag.CustomerId = customerId;
            OverviewModel<SubscriptionResponse> model = await _subscriptionOverviewClient.GetList(customerId);
            return View(model);
        }

        [HttpGet]
        public async Task<ViewResult> ApiUrl([FromQuery]string url) {
            OverviewModel<SubscriptionResponse> model = await _subscriptionOverviewClient.GetListByUrl(url);
            return View(nameof(this.Index), model);
        }

        [HttpGet]
        public ViewResult Create(string customerId) {
            CreateSubscriptionModel model = new CreateSubscriptionModel() {
                CustomerId = customerId,
                Amount = 10,
                Currency = Currency.EUR
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriptionModel model) {
            if (!ModelState.IsValid) {
                return View();
            }

            await _subscriptionStorageClient.Create(model);
            return RedirectToAction(nameof(this.Index), new { customerId = model.CustomerId });
        }
    }
}