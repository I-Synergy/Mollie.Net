using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mollie.Enumerations;
using Mollie.Models;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Subscription;

namespace Mollie.Tests.Api
{
    [TestClass]
    public class SubscriptionTests : BaseApiTestFixture
    {
        [TestMethod]
        public async Task CanRetrieveSubscriptionList() {
            // Given
            string customerId = await GetFirstCustomerWithValidMandate();

            // When: Retrieve subscription list with default settings
            ListResponse<SubscriptionResponse> response = await SubscriptionClient.GetSubscriptionListAsync(customerId);

            // Then
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Items);
        }

        [TestMethod]
        public async Task ListSubscriptionsNeverReturnsMoreCustomersThenTheNumberOfRequestedSubscriptions() {
            // Given: Number of customers requested is 5
            string customerId = await GetFirstCustomerWithValidMandate();
            int numberOfSubscriptions = 5;

            // When: Retrieve 5 subscriptions
            ListResponse<SubscriptionResponse> response = await SubscriptionClient.GetSubscriptionListAsync(customerId, null, numberOfSubscriptions);

            // Then
            Assert.IsTrue(response.Items.Count <= numberOfSubscriptions);
        }

        [TestMethod]
        public async Task CanCreateSubscription() {
            // Given
            string customerId = await GetFirstCustomerWithValidMandate();
            SubscriptionRequest subscriptionRequest = new SubscriptionRequest
            {
                Amount = new Amount(Currency.EUR, "100.00"),
                Times = 5,
                Interval = "1 month",
                Description = $"Subscription {Guid.NewGuid()}", // Subscriptions must have a unique name
                WebhookUrl = "http://www.google.nl",
                StartDate = DateTime.Now.AddDays(1)
            };

            // When
            SubscriptionResponse subscriptionResponse = await SubscriptionClient.CreateSubscriptionAsync(customerId, subscriptionRequest);

            // Then
            Assert.AreEqual(subscriptionRequest.Amount.Value, subscriptionResponse.Amount.Value);
            Assert.AreEqual(subscriptionRequest.Amount.Currency, subscriptionResponse.Amount.Currency);
            Assert.AreEqual(subscriptionRequest.Times, subscriptionResponse.Times);
            Assert.AreEqual(subscriptionRequest.Interval, subscriptionResponse.Interval);
            Assert.AreEqual(subscriptionRequest.Description, subscriptionResponse.Description);
            Assert.AreEqual(subscriptionRequest.WebhookUrl, subscriptionResponse.WebhookUrl);
            Assert.AreEqual(subscriptionRequest.StartDate.Value.Date, subscriptionResponse.StartDate);
        }

        [TestMethod]
        public async Task CanCancelSubscription() {
            // Given
            string customerId = await GetFirstCustomerWithValidMandate();
            ListResponse<SubscriptionResponse> subscriptions = await SubscriptionClient.GetSubscriptionListAsync(customerId);

            // When
            if (subscriptions.Count > 0) {
                string subscriptionId = subscriptions.Items.First().Id;
                await SubscriptionClient.CancelSubscriptionAsync(customerId, subscriptionId);
                SubscriptionResponse cancelledSubscription = await SubscriptionClient.GetSubscriptionAsync(customerId, subscriptionId);

                // Then
                Assert.AreEqual(cancelledSubscription.Status, SubscriptionStatus.Canceled);
            }
            else {
                Assert.Inconclusive("No subscriptions found that could be cancelled");
            }
        }

        [TestMethod]
        public async Task CanUpdateSubscription() {
            // Given 
            string customerId = await GetFirstCustomerWithValidMandate();
            ListResponse<SubscriptionResponse> subscriptions = await SubscriptionClient.GetSubscriptionListAsync(customerId);

            // When
            if (subscriptions.Count > 0)
            {
                string subscriptionId = subscriptions.Items.First().Id;
                SubscriptionUpdateRequest request = new SubscriptionUpdateRequest()
                {
                    Description = $"Updated subscription {Guid.NewGuid()}"
                };
                SubscriptionResponse response = await SubscriptionClient.UpdateSubscriptionAsync(customerId, subscriptionId, request);

                // Then
                Assert.AreEqual(request.Description, response.Description);
            }
            else {
                Assert.Inconclusive("No subscriptions found that could be cancelled");
            }
        }

        [TestMethod]
        public async Task CanCreateSubscriptionWithMetaData() {
            // If: We create a subscription with meta data
            string json = "{\"order_id\":\"4.40\"}";
            string customerId = await GetFirstCustomerWithValidMandate();
            SubscriptionRequest subscriptionRequest = new SubscriptionRequest
            {
                Amount = new Amount(Currency.EUR, "100.00"),
                Times = 5,
                Interval = "1 month",
                Description = $"Subscription {Guid.NewGuid()}", // Subscriptions must have a unique name
                WebhookUrl = "http://www.google.nl",
                StartDate = DateTime.Now.AddDays(1),
                Metadata = json
            };

            // When We send the subscription request to Mollie
            SubscriptionResponse result = await SubscriptionClient.CreateSubscriptionAsync(customerId, subscriptionRequest);

            // Then: Make sure we get the same json result as metadata
            Assert.AreEqual(json, result.Metadata);
        }

        public async Task<string> GetFirstCustomerWithValidMandate() {
            ListResponse<CustomerResponse> customers = await CustomerClient.GetCustomerListAsync();
            
            foreach (CustomerResponse customer in customers.Items) {
                ListResponse<MandateResponse> mandates = await MandateClient.GetMandateListAsync(customer.Id);
                if (mandates.Items.Any(x => x.Status == MandateStatus.Valid)) {
                    return customer.Id;
                }
            }

            Assert.Inconclusive("No customers with valid mandate found. Unable to test subscription API");
            return null;
        }
    }
}
