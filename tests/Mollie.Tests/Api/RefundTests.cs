using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class RefundTests : BaseApiTestFixture
    {
        [TestMethod]
        [Ignore("We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanCreateRefund() {
            // If: We create a payment
            string amount = "100.00";
            PaymentResponse payment = await this.CreatePayment(amount);

            // We can only test this if you make the payment using the payment.Links.Checkout property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break(); 

            // When: We attempt to refund this payment
            RefundRequest refundRequest = new RefundRequest() {
                Amount = new Amount(Currency.EUR, amount)
            };
            RefundResponse refundResponse = await RefundClient.CreateRefundAsync(payment.Id, refundRequest);

            // Then
            Assert.IsNotNull(refundResponse);
        }

        [TestMethod]
        [Ignore("We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanCreatePartialRefund() {
            // If: We create a payment of 250 euro
            PaymentResponse payment = await this.CreatePayment("250.00");

            // We can only test this if you make the payment using the payment.Links.PaymentUrl property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break();

            // When: We attempt to refund 50 euro
            RefundRequest refundRequest = new RefundRequest() {
                Amount = new Amount(Currency.EUR, "50.00")
            };
            RefundResponse refundResponse = await RefundClient.CreateRefundAsync(payment.Id, refundRequest);

            // Then
            Assert.AreEqual("50.00", refundResponse.Amount.Value);
        }

        [TestMethod]
        [Ignore("We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanRetrieveSingleRefund() {
            // If: We create a payment
            PaymentResponse payment = await this.CreatePayment();
            // We can only test this if you make the payment using the payment.Links.PaymentUrl property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break();

            RefundRequest refundRequest = new RefundRequest() {
                Amount = new Amount(Currency.EUR, "50.00")
            };
            RefundResponse refundResponse = await RefundClient.CreateRefundAsync(payment.Id, refundRequest);

            // When: We attempt to retrieve this refund
            RefundResponse result = await RefundClient.GetRefundAsync(payment.Id, refundResponse.Id);

            // Then
            Assert.IsNotNull(result);
            Assert.AreEqual(refundResponse.Id, result.Id);
            Assert.AreEqual(refundResponse.Amount.Value, result.Amount.Value);
            Assert.AreEqual(refundResponse.Amount.Currency, result.Amount.Currency);
        }

        [TestMethod]
        [Ignore("Outcome depends on payment methods active in portal")]
        public async Task CanRetrieveRefundList() {
            // If: We create a payment
            PaymentResponse payment = await this.CreatePayment();

            // When: Retrieve refund list for this payment
            ListResponse<RefundResponse> refundList = await RefundClient.GetRefundListAsync(payment.Id);

            // Then
            Assert.IsNotNull(refundList);
            Assert.IsNotNull(refundList.Items);
        }

        private async Task<PaymentResponse> CreatePayment(string amount = "100.00") {
            PaymentRequest paymentRequest = new CreditCardPaymentRequest();
            paymentRequest.Amount = new Amount(Currency.EUR, amount);
            paymentRequest.Description = "Description";
            paymentRequest.RedirectUrl = this.DefaultRedirectUrl;

            return await PaymentClient.CreatePaymentAsync(paymentRequest);
        }
    }
}
