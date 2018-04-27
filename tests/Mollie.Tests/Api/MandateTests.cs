using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Tests.Base;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Mollie.Tests
{
    [Collection(nameof(BaseApiTestFixture))]
    public class MandateTests
    {
        protected BaseApiTestFixture fixture;

        public MandateTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact]
        public async Task CanRetrieveMandateList()
        {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await fixture.CustomerClient.GetCustomerListAsync();

            if (customers.TotalCount > 0)
            {
                // When: Retrieve mandate list with default settings
                ListResponse<MandateResponse> response = await fixture.MandateClient.GetMandateListAsync(customers.Data.First().Id);

                // Then
                Assert.NotNull(response);
            }
        }

        [Fact]
        public async Task ListMandatesNeverReturnsMoreCustomersThenTheNumberOfRequestedMandates()
        {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await fixture.CustomerClient.GetCustomerListAsync();

            if (customers.TotalCount > 0)
            {
                // If: Number of customers requested is 5
                int numberOfMandates = 5;

                // When: Retrieve 5 mandates
                ListResponse<MandateResponse> response = await fixture.MandateClient.GetMandateListAsync(customers.Data.First().Id, 0, numberOfMandates);

                // Then
                Assert.True(response.Data.Count <= numberOfMandates);
            }
        }

        [Fact]
        public async Task CanCreateMandate()
        {
            // We can only test this if there are customers
            ListResponse<CustomerResponse> customers = await fixture.CustomerClient.GetCustomerListAsync();
            if (customers.TotalCount > 0)
            {
                // If: We create a new mandate request
                MandateRequest mandateRequest = new MandateRequest()
                {
                    ConsumerAccount = "NL26ABNA0516682814",
                    ConsumerName = "John Doe"
                };

                // When: We send the mandate request
                MandateResponse mandateResponse = await fixture.MandateClient.CreateMandateAsync(customers.Data.First().Id, mandateRequest);

                // Then: Make sure we created a new mandate
                Assert.Equal(mandateRequest.ConsumerAccount, mandateResponse.Details.ConsumerAccount);
                Assert.Equal(mandateRequest.ConsumerName, mandateResponse.Details.ConsumerName);
            }
        }
    }
}
