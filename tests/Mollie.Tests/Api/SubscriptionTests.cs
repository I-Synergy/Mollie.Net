using Mollie.Enumerations;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Subscription;
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
    public class SubscriptionTests
    {
        protected BaseApiTestFixture fixture;

        public SubscriptionTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact(Skip = "No customers with valid mandate found.Unable to test subscription API")]
        public async Task CanRetrieveMandateList()
        {
            // Given
            string customerId = await this.GetFirstCustomerWithValidMandate();

            // When: Retrieve subscription list with default settings
            ListResponse<SubscriptionResponse> response = await fixture.SubscriptionClient.GetSubscriptionListAsync(customerId);

            // Then
            Assert.NotNull(response);
        }

        [Fact(Skip = "No customers with valid mandate found.Unable to test subscription API")]
        public async Task ListSubscriptionsNeverReturnsMoreCustomersThenTheNumberOfRequestedSubscriptions()
        {
            // Given: Number of customers requested is 5
            string customerId = await this.GetFirstCustomerWithValidMandate();
            int numberOfSubscriptions = 5;

            // When: Retrieve 5 subscriptions
            ListResponse<SubscriptionResponse> response = await fixture.SubscriptionClient.GetSubscriptionListAsync(customerId, 0, numberOfSubscriptions);

            // Then
            Assert.True(response.Data.Count <= numberOfSubscriptions);
        }

        [Fact(Skip = "No customers with valid mandate found.Unable to test subscription API")]
        public async Task CanCreateSubscription()
        {
            // Given
            string customerId = await this.GetFirstCustomerWithValidMandate();
            SubscriptionRequest subscriptionRequest = new SubscriptionRequest();
            subscriptionRequest.Amount = 100;
            subscriptionRequest.Times = 5;
            subscriptionRequest.Interval = "1 month";
            subscriptionRequest.Description = $"Subscription {DateTime.Now}"; // Subscriptions must have a unique name
            subscriptionRequest.WebhookUrl = "http://www.google.nl";
            subscriptionRequest.StartDate = DateTime.Now.AddDays(1);

            // When
            SubscriptionResponse subscriptionResponse = await fixture.SubscriptionClient.CreateSubscriptionAsync(customerId, subscriptionRequest);

            // Then
            Assert.Equal(subscriptionRequest.Amount, subscriptionResponse.Amount);
            Assert.Equal(subscriptionRequest.Times, subscriptionResponse.Times);
            Assert.Equal(subscriptionRequest.Interval, subscriptionResponse.Interval);
            Assert.Equal(subscriptionRequest.Description, subscriptionResponse.Description);
            Assert.Equal(subscriptionRequest.WebhookUrl, subscriptionResponse.Links.WebhookUrl);
            Assert.Equal(subscriptionRequest.StartDate.Value.Date, subscriptionResponse.StartDate);
        }

        [Fact(Skip = "No customers with valid mandate found.Unable to test subscription API")]
        public async Task CanCancelSubscription()
        {
            // Given
            string customerId = await this.GetFirstCustomerWithValidMandate();
            ListResponse<SubscriptionResponse> subscriptions = await fixture.SubscriptionClient.GetSubscriptionListAsync(customerId);

            // When
            if (subscriptions.TotalCount > 0)
            {
                string subscriptionId = subscriptions.Data.First().Id;
                await fixture.SubscriptionClient.CancelSubscriptionAsync(customerId, subscriptionId);
                SubscriptionResponse cancelledSubscription = await fixture.SubscriptionClient.GetSubscriptionAsync(customerId, subscriptionId);

                Assert.True(cancelledSubscription.Status == SubscriptionStatus.Cancelled);
            }
        }

        public async Task<string> GetFirstCustomerWithValidMandate()
        {
            ListResponse<CustomerResponse> customers = await fixture.CustomerClient.GetCustomerListAsync();

            foreach (CustomerResponse customer in customers.Data)
            {
                ListResponse<MandateResponse> mandates = await fixture.MandateClient.GetMandateListAsync(customer.Id);
                if (mandates.Data.Any(x => x.Status == MandateStatus.Valid))
                {
                    return customer.Id;
                }
            }
            return null;
        }
    }
}
