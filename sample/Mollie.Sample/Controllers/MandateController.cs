using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Models.Mandate;
using Mollie.Sample.Models;
using Mollie.Sample.Services.Mandate;

namespace Mollie.Sample.Controllers {
    public class MandateController : Controller {
        private readonly IMandateOverviewClient _mandateOverviewClient;
        private readonly IMandateStorageClient _mandateStorageClient;

        public MandateController(IMandateOverviewClient mandateOverviewClient, IMandateStorageClient mandateStorageClient) {
            _mandateOverviewClient = mandateOverviewClient;
            _mandateStorageClient = mandateStorageClient;
        }

        public async Task<ViewResult> Index(string customerId) {
            ViewBag.CustomerId = customerId;
            OverviewModel<MandateResponse> model = await _mandateOverviewClient.GetList(customerId);
            return View(model);
        }

        [HttpGet]
        public async Task<ViewResult> ApiUrl([FromQuery]string url) {
            OverviewModel<MandateResponse> model = await _mandateOverviewClient.GetListByUrl(url);
            return View(nameof(this.Index), model);
        }

        [HttpGet]
        public ViewResult Create(string customerId) {
            ViewBag.CustomerId = customerId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(string customerId) {
            await _mandateStorageClient.Create(customerId);
            return RedirectToAction("Index", new { customerId });
        }
    }
}