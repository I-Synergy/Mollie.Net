using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Client;
using Mollie.Models;
using Mollie.Models.Payment.Request;
using System;
using System.Linq;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class ApiExceptionTests : BaseApiTestFixture
    {
        [TestMethod]
        public void ShouldThrowMollieApiExceptionWhenInvalidParametersAreGiven()
        {
            // If: we create a payment request with invalid parameters
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = new Amount(Currency.EUR, "100.00"),
                Description = null,
                RedirectUrl = null
            };

            // Then: Send the payment request to the Mollie Api, this should throw a mollie api exception
            AggregateException aggregateException = Assert.ThrowsException<AggregateException>(() => PaymentClient.CreatePaymentAsync(paymentRequest).Wait());
            MollieApiException mollieApiException = aggregateException.InnerExceptions.FirstOrDefault(x => x.GetType() == typeof(MollieApiException)) as MollieApiException;
            Assert.IsNotNull(mollieApiException);
            Assert.IsNotNull(mollieApiException.Details);
            Assert.IsTrue(!string.IsNullOrEmpty(mollieApiException.Details.Detail));
        }
    }
}
