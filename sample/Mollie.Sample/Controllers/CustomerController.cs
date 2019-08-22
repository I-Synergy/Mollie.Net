using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Models.Customer;
using Mollie.Sample.Models;
using Mollie.Sample.Services.Customer;

namespace Mollie.Sample.Controllers
{
    public class CustomerController : Controller {
        private readonly ICustomerOverviewClient _customerOverviewClient;
        private readonly ICustomerStorageClient _customerStorageClient;

        public CustomerController(ICustomerOverviewClient customerOverviewClient, ICustomerStorageClient customerStorageClient) {
            _customerOverviewClient = customerOverviewClient;
            _customerStorageClient = customerStorageClient;
        }

        [HttpGet]
        public async Task<ViewResult> Index() {
            OverviewModel<CustomerResponse> model = await _customerOverviewClient.GetList();
            return View(model);
        }

        [HttpGet]
        public async Task<ViewResult> ApiUrl([FromQuery]string url) {
            OverviewModel<CustomerResponse> model = await _customerOverviewClient.GetListByUrl(url);
            return View(nameof(this.Index), model);
        }

        [HttpGet]
        public ViewResult Create() {
            CreateCustomerModel model = new CreateCustomerModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerModel model) {
            if (!ModelState.IsValid) {
                return View();
            }

            await _customerStorageClient.Create(model);
            return RedirectToAction(nameof(this.Index));
        }
    }
}