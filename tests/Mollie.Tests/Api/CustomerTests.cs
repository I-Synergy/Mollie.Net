using Mollie.Enumerations;
using Mollie.Models.Customer;
using Mollie.Models.List;
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
    public class CustomerTests
    {
        protected BaseApiTestFixture fixture;

        public CustomerTests(BaseApiTestFixture _fixture)
        {
            fixture = _fixture;
        }

        [Fact]
        public async Task CanRetrieveCustomerList()
        {
            // When: Retrieve customer list with default settings
            ListResponse<CustomerResponse> response = await fixture.CustomerClient.GetCustomerListAsync();

            // Then
            Assert.NotNull(response);
        }

        [Fact]
        public async Task ListCustomersNeverReturnsMoreCustomersThenTheNumberOfRequestedCustomers()
        {
            // If: Number of customers requested is 5
            int numberOfCustomers = 5;

            // When: Retrieve 5 customers
            ListResponse<CustomerResponse> response = await fixture.CustomerClient.GetCustomerListAsync(0, numberOfCustomers);

            // Then
            Assert.True(response.Data.Count <= numberOfCustomers);
        }

        [Fact]
        public async Task CanCreateNewCustomer()
        {
            // If: We create a customer request with only the required parameters
            string name = "Smit";
            string email = "johnsmit@mollie.com";

            // When: We send the customer request to Mollie
            CustomerResponse result = await this.CreateCustomer(name, email);

            // Then: Make sure the requested parameters match the response parameter values
            Assert.NotNull(result);
            Assert.Equal(name, result.Name);
            Assert.Equal(email, result.Email);
        }

        [Fact]
        public async Task CanRetrieveRecentPaymentMethods()
        {
            // If: We create a new customer and create several payment for the customer
            CustomerResponse newCustomer = await this.CreateCustomer("Smit", "johnsmit@mollie.com");
            await this.CreatePayment(newCustomer.Id, PaymentMethods.BankTransfer);
            await this.CreatePayment(newCustomer.Id, PaymentMethods.Ideal);
            await this.CreatePayment(newCustomer.Id, PaymentMethods.CreditCard);

            // When: retrieving the customer again
            CustomerResponse customerResponse = await fixture.CustomerClient.GetCustomerAsync(newCustomer.Id);

            // Then recent payment methods should contain the payment method
            Assert.NotNull(customerResponse.RecentlyUsedMethods);
            Assert.NotNull(customerResponse.RecentlyUsedMethods.FirstOrDefault(x => x == PaymentMethods.BankTransfer));
            Assert.NotNull(customerResponse.RecentlyUsedMethods.FirstOrDefault(x => x == PaymentMethods.Ideal));
            Assert.NotNull(customerResponse.RecentlyUsedMethods.FirstOrDefault(x => x == PaymentMethods.CreditCard));

        }

        private Task<PaymentResponse> CreatePayment(string customerId, PaymentMethods method)
        {
            PaymentRequest paymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Description = "Description",
                RedirectUrl = fixture.DefaultRedirectUrl,
                Method = method,
                CustomerId = customerId
            };
            return fixture.PaymentClient.CreatePaymentAsync(paymentRequest);
        }

        private Task<CustomerResponse> CreateCustomer(string name, string email)
        {
            CustomerRequest customerRequest = new CustomerRequest()
            {
                Email = email,
                Name = name,
                Locale = Locale.NL
            };

            return fixture.CustomerClient.CreateCustomerAsync(customerRequest);
        }
    }
}
