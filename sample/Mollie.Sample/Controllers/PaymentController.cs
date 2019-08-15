﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Models;
using Mollie.Models.Payment.Response;
using Mollie.Sample.Models;
using Mollie.Sample.Services.Payment;

namespace Mollie.Sample.Controllers
{
    public class PaymentController : Controller {
        private readonly IPaymentOverviewClient _paymentOverviewClient;
        private readonly IPaymentStorageClient _paymentStorageClient;

        public PaymentController(IPaymentOverviewClient paymentOverviewClient, IPaymentStorageClient paymentStorageClient) {
            this._paymentOverviewClient = paymentOverviewClient;
            this._paymentStorageClient = paymentStorageClient;
        }

        [HttpGet]
        public async Task<ViewResult> Index() {
            OverviewModel<PaymentResponse> model = await this._paymentOverviewClient.GetList();
            return this.View(model);
        }

        [HttpGet]
        public async Task<ViewResult> ApiUrl([FromQuery]string url) {
            OverviewModel<PaymentResponse> model = await this._paymentOverviewClient.GetListByUrl(url);
            return this.View(nameof(this.Index), model);
        }

        [HttpGet]
        public ViewResult Create() {
            CreatePaymentModel model = new CreatePaymentModel() {
                Amount = 10,
                Currency = Currency.EUR
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentModel model) {
            if (!this.ModelState.IsValid) {
                return this.View();
            }

            await this._paymentStorageClient.Create(model);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}