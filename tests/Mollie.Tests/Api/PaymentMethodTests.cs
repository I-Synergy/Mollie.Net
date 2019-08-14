using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Enumerations;
using Mollie.Models.List;
using Mollie.Models.PaymentMethod;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class PaymentMethodTests : BaseApiTestFixture
    {

        [TestMethod]
        public async Task CanRetrievePaymentMethodList() {
            // When: Retrieve payment list with default settings
            ListResponse<PaymentMethodResponse> response = await PaymentMethodClient.GetPaymentMethodListAsync();

            // Then: Make sure it can be retrieved
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Items);
        }

        [DataTestMethod]
        [DataRow(PaymentMethods.Ideal)]
        [DataRow(PaymentMethods.CreditCard)]
        [DataRow(PaymentMethods.Bancontact)]
        [DataRow(PaymentMethods.Sofort)]
        [DataRow(PaymentMethods.BankTransfer)]
        [DataRow(PaymentMethods.Belfius)]
        [DataRow(PaymentMethods.Bitcoin)]
        [DataRow(PaymentMethods.PayPal)]
        [DataRow(PaymentMethods.Kbc)]
        public async Task CanRetrieveSinglePaymentMethod(PaymentMethods method) {
            // When: retrieving a payment method
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(method);

            // Then: Make sure it can be retrieved
            Assert.IsNotNull(paymentMethod);
            Assert.IsNotNull(paymentMethod.Id);
            Assert.AreEqual(method, paymentMethod.Id);
        }

        [TestMethod]
        public async Task CanRetrieveIdealIssuers() {
            // When: retrieving the ideal method we can include the issuers
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, true);

            // Then: We should have one or multiple issuers
            Assert.IsNotNull(paymentMethod);
            Assert.IsTrue(paymentMethod.Issuers.Any());
        }

        [TestMethod]
        public async Task DoNotRetrieveIssuersWhenIncludeIsFalse() {
            // When: retrieving the ideal method with the include parameter set to false
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, false);

            // Then: Issuers should not be included
            Assert.IsNull(paymentMethod.Issuers);
        }

        [TestMethod]
        public async Task DoNotRetrieveIssuersWhenIncludeIsNull() {
            // When: retrieving the ideal method with the include parameter set to null
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, null);

            // Then: Issuers should not be included
            Assert.IsNull(paymentMethod.Issuers);
        }

        [TestMethod]
        public async Task CanRetrievePricing() {
            // When: retrieving the ideal method we can include the issuers
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, includePricing: true);

            // Then: We should have one or multiple issuers
            Assert.IsNotNull(paymentMethod);
            Assert.IsTrue(paymentMethod.Pricing.Any());
        }

        [TestMethod]
        public async Task DoNotRetrievePricingWhenIncludeIsFalse() {
            // When: retrieving the ideal method with the include parameter set to false
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, includePricing: false);

            // Then: Issuers should not be included
            Assert.IsNull(paymentMethod.Pricing);
        }

        [TestMethod]
        public async Task DoNotRetrievePricingWhenIncludeIsNull() {
            // When: retrieving the ideal method with the include parameter set to null
            PaymentMethodResponse paymentMethod = await PaymentMethodClient.GetPaymentMethodAsync(PaymentMethods.Ideal, includePricing: null);

            // Then: Issuers should not be included
            Assert.IsNull(paymentMethod.Pricing);
        }

        [TestMethod]
        public async Task CanRetrieveAllMethods() {
            // When: retrieving the all mollie payment methods
            ListResponse<PaymentMethodResponse> paymentMethods = await PaymentMethodClient.GetAllPaymentMethodListAsync();

            // Then: We should have multiple issuers
            Assert.IsNotNull(paymentMethods);
            Assert.IsTrue(paymentMethods.Items.Any());
        }

        [TestMethod]
        public async Task CanRetrievePricingForAllMethods() {
            // When: retrieving the ideal method we can include the issuers
            ListResponse<PaymentMethodResponse> paymentMethods = await PaymentMethodClient.GetAllPaymentMethodListAsync(includePricing: true);

            // Then: We should have prices available
            Assert.IsTrue(paymentMethods.Items.Any(x => x.Pricing != null && x.Pricing.Any(y => y.Fixed.Value > 0)));
        }

        [TestMethod]
        public async Task CanRetrieveIssuersForAllMethods() {
            // When: retrieving the all mollie payment methods we can include the issuers
            ListResponse<PaymentMethodResponse> paymentMethods = await PaymentMethodClient.GetAllPaymentMethodListAsync(includeIssuers: true);

            // Then: We should have one or multiple issuers
            Assert.IsTrue(paymentMethods.Items.Any(x => x.Issuers != null));
        }

        [TestMethod]
        public async Task CanRetrieveIssuersAndPricingInformation() {
            // When: retrieving the all mollie payment methods we can include the issuers
            ListResponse<PaymentMethodResponse> paymentMethods = await PaymentMethodClient.GetAllPaymentMethodListAsync(includeIssuers: true, includePricing: true);
            
            // Then: We should have one or multiple issuers
            Assert.IsTrue(paymentMethods.Items.Any(x => x.Issuers != null));
            Assert.IsTrue(paymentMethods.Items.Any(x => x.Pricing != null && x.Pricing.Any(y => y.Fixed.Value > 0)));
        }
    }
}