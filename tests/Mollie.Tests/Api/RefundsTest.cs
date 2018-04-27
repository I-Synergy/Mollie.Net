using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Models.Refund;
using Mollie.Tests.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mollie.Tests
{
    [Collection(nameof(BaseApiTestFixture))]
    public class RefundsTest
    {
        protected BaseApiTestFixture fixture;

        public RefundsTest(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

#if DEBUG
#pragma warning disable xUnit1004 // Test methods should not be skipped
        [Fact(Skip = "We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanCreateRefund()
        {
            // If: We create a payment
            PaymentResponse payment = await this.CreatePayment();

            // We can only test this if you make the payment using the payment.Links.PaymentUrl property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break();

            // When: We attempt to refund this payment
            RefundResponse refundResponse = await fixture.RefundClient.CreateRefundAsync(payment.Id);

            // Then
            Assert.NotNull(refundResponse);
        }

        [Fact(Skip = "We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanCreatePartialRefund()
        {
            // If: We create a payment of 250 euro
            PaymentResponse payment = await this.CreatePayment(250);

            // We can only test this if you make the payment using the payment.Links.PaymentUrl property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break();

            // When: We attempt to refund 50 euro
            RefundRequest refundRequest = new RefundRequest()
            {
                Amount = 50
            };
            RefundResponse refundResponse = await fixture.RefundClient.CreateRefundAsync(payment.Id, refundRequest);

            // Then
            Assert.Equal(50, refundResponse.Payment.AmountRefunded);
            Assert.Equal(200, refundResponse.Payment.AmountRemaining);
        }

        [Fact(Skip="We can only test this in debug mode, because we actually have to use the PaymentUrl to make the payment, since Mollie can only refund payments that have been paid")]
        public async Task CanRetrieveSingleRefund()
        {
            // If: We create a payment
            PaymentResponse payment = await this.CreatePayment();
            // We can only test this if you make the payment using the payment.Links.PaymentUrl property. 
            // If you don't do this, this test will fail because we can only refund payments that have been paid
            Debugger.Break();
            RefundResponse refundResponse = await fixture.RefundClient.CreateRefundAsync(payment.Id);

            // When: We attempt to retrieve this refund
            RefundResponse result = await fixture.RefundClient.GetRefundAsync(payment.Id, refundResponse.Id);

            // Then
            Assert.NotNull(result);
            Assert.Equal(refundResponse.Id, result.Id);
            Assert.Equal(refundResponse.Payment.AmountRefunded, result.Payment.AmountRefunded);
            Assert.Equal(refundResponse.Payment.AmountRemaining, result.Payment.AmountRemaining);
        }
#pragma warning restore xUnit1004 // Test methods should not be skipped
#endif

        [Fact(Skip = "The payment method is not enabled in your website profile.")]
        public async Task CanRetrieveRefundList()
        {
            // If: We create a payment
            PaymentResponse payment = await this.CreatePayment();

            // When: Retrieve refund list for this payment
            ListResponse<RefundResponse> refundList = await fixture.RefundClient.GetRefundListAsync(payment.Id);

            // Then
            Assert.NotNull(refundList);
        }

        private async Task<PaymentResponse> CreatePayment(decimal amount = 100)
        {
            PaymentRequest paymentRequest = new CreditCardPaymentRequest
            {
                Amount = amount,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl
            };

            return await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);
        }
    }
}
