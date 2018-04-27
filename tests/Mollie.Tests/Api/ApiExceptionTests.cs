using Mollie.Exceptions;
using Mollie.Models.Payment.Request;
using Mollie.Tests.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mollie.Tests
{
    [Collection(nameof(BaseApiTestFixture))]
    public class ApiExceptionTests
    {
        protected BaseApiTestFixture fixture;

        public ApiExceptionTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact]
        public async Task ShouldThrowMollieApiExceptionWhenInvalidParametersAreGiven()
        {
            // If: we create a payment request with invalid parameters
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = -100,
                Description = null,
                RedirectUrl = null
            };

            // Then: Send the payment request to the Mollie Api, this should throw a mollie api exception
            MollieException mollieApiException = 
                await Assert.ThrowsAsync<MollieException>(async () => 
                    await fixture.PaymentClient.CreatePaymentAsync(paymentRequest).ConfigureAwait(false));

            Assert.NotNull(mollieApiException);
            Assert.NotNull(mollieApiException.Details);
            Assert.True(!String.IsNullOrEmpty(mollieApiException.Details.Message));

        }
    }
}
