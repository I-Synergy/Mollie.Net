﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mollie.Sample.Services.Payment.Refund;

namespace Mollie.Sample.Controllers {
    public class RefundController : Controller {
        private readonly IRefundPaymentClient _refundPaymentClient;

        public RefundController(IRefundPaymentClient refundPaymentClient) {
            this._refundPaymentClient = refundPaymentClient;
        }

        [HttpPost]
        public async Task<IActionResult> Refund(string paymentId) {
            await this._refundPaymentClient.Refund(paymentId);
            return this.RedirectToAction(nameof(PaymentController.Index), "Payment");
        }
    }
}