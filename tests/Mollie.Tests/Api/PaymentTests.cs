using Mollie.Enumerations;
using Mollie.Exceptions;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Payment;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Tests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mollie.Tests
{
    [Collection(nameof(BaseApiTestFixture))]
    public class PaymentTests
    {
        protected BaseApiTestFixture fixture;

        public PaymentTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact]
        public async Task CanRetrievePaymentList()
        {
            // When: Retrieve payment list with default settings
            ListResponse<PaymentResponse> response = await fixture.PaymentClient.GetPaymentListAsync();

            // Then
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ListPaymentsNeverReturnsMorePaymentsThenTheNumberOfRequestedPayments()
        {
            // If: Number of payments requested is 5
            int numberOfPayments = 5;

            // When: Retrieve 5 payments
            ListResponse<PaymentResponse> response = await fixture.PaymentClient.GetPaymentListAsync(0, numberOfPayments);

            // Then
            Assert.True(response.Data.Count <= numberOfPayments);
        }

        [Fact]
        public async Task CanCreateDefaultPaymentWithOnlyRequiredFields()
        {
            // If: we create a payment request with only the required parameters
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl
            };

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);

            // Then: Make sure we get a valid response
            Assert.NotNull(result);
            Assert.Equal(paymentRequest.Amount, result.Amount);
            Assert.Equal(paymentRequest.Description, result.Description);
            Assert.Equal(paymentRequest.RedirectUrl, result.Links.RedirectUrl);
        }

        [Fact]
        public async Task CanCreateDefaultPaymentWithAllFields()
        {
            // If: we create a payment request where all parameters have a value
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                Locale = Locale.NL,
                Metadata = @"{""firstName"":""John"",""lastName"":""Doe""}",
                Method = PaymentMethods.BankTransfer,
                WebhookUrl = fixture.DefaultWebhookUrl
            };

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);

            // Then: Make sure all requested parameters match the response parameter values
            Assert.NotNull(result);
            Assert.Equal(paymentRequest.Amount, result.Amount);
            Assert.Equal(paymentRequest.Description, result.Description);
            Assert.Equal(paymentRequest.RedirectUrl, result.Links.RedirectUrl);
            Assert.Equal(paymentRequest.Locale, result.Locale);
            Assert.Equal(paymentRequest.Metadata, result.Metadata);
            Assert.Equal(paymentRequest.WebhookUrl, result.Links.WebhookUrl);
        }

        [Theory]
        [InlineData(typeof(IdealPaymentRequest), PaymentMethods.Ideal, typeof(IdealPaymentResponse))]
        [InlineData(typeof(CreditCardPaymentRequest), PaymentMethods.CreditCard, typeof(CreditCardPaymentResponse))]
        [InlineData(typeof(PaymentRequest), PaymentMethods.MisterCash, typeof(MisterCashPaymentResponse))]
        [InlineData(typeof(PaymentRequest), PaymentMethods.Sofort, typeof(SofortPaymentResponse))]
        [InlineData(typeof(BankTransferPaymentRequest), PaymentMethods.BankTransfer, typeof(BankTransferPaymentResponse))]
        [InlineData(typeof(PayPalPaymentRequest), PaymentMethods.PayPal, typeof(PayPalPaymentResponse), Skip = "The payment method is not enabled in your website profile.")]
        [InlineData(typeof(PaymentRequest), PaymentMethods.Bitcoin, typeof(BitcoinPaymentResponse), Skip = "The payment method is not enabled in your website profile.")]
        [InlineData(typeof(PaymentRequest), PaymentMethods.Belfius, typeof(BelfiusPaymentResponse), Skip = "The payment method is not enabled in your website profile.")]
        [InlineData(typeof(KbcPaymentRequest), PaymentMethods.Kbc, typeof(KbcPaymentResponse), Skip = "The payment method is not enabled in your website profile.")]
        [InlineData(typeof(PaymentRequest), null, typeof(PaymentResponse))]
        public async Task CanCreateSpecificPaymentType(Type paymentType, PaymentMethods? paymentMethod, Type expectedResponseType)
        {
            // If: we create a specific payment type with some bank transfer specific values
            PaymentRequest paymentRequest = (PaymentRequest)Activator.CreateInstance(paymentType);
            paymentRequest.Amount = 100;
            paymentRequest.Description = "Description";
            paymentRequest.RedirectUrl = fixture.DefaultRedirectUrl;
            paymentRequest.Method = paymentMethod;

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);

            // Then: Make sure all requested parameters match the response parameter values
            Assert.NotNull(result);
            Assert.Equal(expectedResponseType, result.GetType());
            Assert.Equal(paymentRequest.Amount, result.Amount);
            Assert.Equal(paymentRequest.Description, result.Description);
            Assert.Equal(paymentRequest.RedirectUrl, result.Links.RedirectUrl);
        }

        [Fact]
        public async Task CanCreatePaymentAndRetrieveIt()
        {
            // If: we create a new payment request
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                Locale = Locale.DE
            };

            // When: We send the payment request to Mollie and attempt to retrieve it
            PaymentResponse paymentResponse = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);
            PaymentResponse result = await fixture.PaymentClient.GetPaymentAsync(paymentResponse.Id);

            // Then
            Assert.NotNull(result);
            Assert.Equal(paymentResponse.Id, result.Id);
            Assert.Equal(paymentResponse.Amount, result.Amount);
            Assert.Equal(paymentResponse.Description, result.Description);
            Assert.Equal(paymentResponse.Links.RedirectUrl, result.Links.RedirectUrl);
        }

        [Fact(Skip = "No customers or mandates found. Unable to test recurring payment tests")]
        public async Task CanCreateRecurringPaymentAndRetrieveIt()
        {
            // If: we create a new recurring payment
            MandateResponse mandate = await this.GetFirstValidMandate();
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                RecurringType = RecurringType.First,
                CustomerId = mandate.CustomerId
            };

            // When: We send the payment request to Mollie and attempt to retrieve it
            PaymentResponse paymentResponse = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);
            PaymentResponse result = await fixture.PaymentClient.GetPaymentAsync(paymentResponse.Id);

            // Then: Make sure the recurringtype parameter is entered
            Assert.Equal(RecurringType.First, result.RecurringType);
        }

        [Fact]
        public async Task CanCreatePaymentWithMetaData()
        {
            // If: We create a payment with meta data
            string json = "{\"order_id\":\"4.40\"}";
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                Metadata = json
            };

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);

            // Then: Make sure we get the same json result as metadata
            Assert.Equal(json, result.Metadata);
        }

        [Fact]
        public async Task CanCreatePaymentWithCustomMetaDataClass()
        {
            // If: We create a payment with meta data
            CustomMetadataClass metadataRequest = new CustomMetadataClass()
            {
                OrderId = 1,
                Description = "Custom description"
            };

            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
            };
            paymentRequest.SetMetadata(metadataRequest);

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);
            CustomMetadataClass metadataResponse = result.GetMetadata<CustomMetadataClass>();

            // Then: Make sure we get the same json result as metadata
            Assert.NotNull(metadataResponse);
            Assert.Equal(metadataRequest.OrderId, metadataResponse.OrderId);
            Assert.Equal(metadataRequest.Description, metadataResponse.Description);
        }

        [Fact(Skip = "No customers or mandates found. Unable to test recurring payment tests")]
        public async Task CanCreatePaymentWithMandate()
        {
            // If: We create a payment with a mandate id
            MandateResponse validMandate = await this.GetFirstValidMandate();
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                RecurringType = RecurringType.Recurring,
                CustomerId = validMandate.CustomerId,
                MandateId = validMandate.Id
            };

            // When: We send the payment request to Mollie
            PaymentResponse result = await fixture.PaymentClient.CreatePaymentAsync(paymentRequest);

            // Then: Make sure we get the mandate id back in the details
            Assert.Equal(validMandate.Id, result.MandateId);
        }

        [Fact]
        public Task PaymentWithInvalidJsonThrowsException()
        {
            // If: We create a payment with invalid json
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                Metadata = "IAmNotAValidJsonString"
            };

            // When + Then: We send the payment request to Mollie, we expect the exception
            return Assert.ThrowsAsync<MollieException>(async () => await fixture.PaymentClient.CreatePaymentAsync(paymentRequest));
        }

        private async Task<MandateResponse> GetFirstValidMandate()
        {
            ListResponse<CustomerResponse> customers = await fixture.CustomerClient.GetCustomerListAsync();

            foreach (CustomerResponse customer in customers?.Data)
            {
                ListResponse<MandateResponse> customerMandates = await fixture.MandateClient.GetMandateListAsync(customer.Id);

                MandateResponse firstValidMandate = customerMandates?.Data.FirstOrDefault(x => x.Status == MandateStatus.Valid);

                if (firstValidMandate != null)
                {
                    return firstValidMandate;
                }
            }

            return null;
        }
    }

    public class CustomMetadataClass
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
    }
}
