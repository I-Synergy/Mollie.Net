using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class MandateTests : BaseApiTestFixture
    {
        [TestMethod]
        public async Task CanRetrieveMandateList() {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await CustomerClient.GetCustomerListAsync();

            if (customers.Count > 0) {
                // When: Retrieve mandate list with default settings
                ListResponse<MandateResponse> response = await MandateClient.GetMandateListAsync(customers.Items.First().Id);

                // Then
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.Items);
            }
        }

        [TestMethod]
        public async Task ListMandatesNeverReturnsMoreCustomersThenTheNumberOfRequestedMandates() {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await CustomerClient.GetCustomerListAsync();

            if (customers.Count > 0) {
                // If: Number of customers requested is 5
                int numberOfMandates = 5;

                // When: Retrieve 5 mandates
                ListResponse<MandateResponse> response = await MandateClient.GetMandateListAsync(customers.Items.First().Id, null, numberOfMandates);

                // Then
                Assert.IsTrue(response.Items.Count <= numberOfMandates);
            }
        }

        [TestMethod]
        public async Task CanCreateMandate() {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await CustomerClient.GetCustomerListAsync();
            if (customers.Count > 0) {
                // If: We create a new mandate request
                MandateRequest mandateRequest = new MandateRequest() {
                    ConsumerAccount = "NL26ABNA0516682814",
                    ConsumerName = "John Doe"
                };

                // When: We send the mandate request
                MandateResponse mandateResponse = await MandateClient.CreateMandateAsync(customers.Items.First().Id, mandateRequest);

                // Then: Make sure we created a new mandate
                Assert.AreEqual(mandateRequest.ConsumerAccount, mandateResponse.Details.ConsumerAccount);
                Assert.AreEqual(mandateRequest.ConsumerName, mandateResponse.Details.ConsumerName);
            }
        }
    }
}
