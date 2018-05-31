using Mollie.Abstract;
using Mollie.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Mollie.Tests.Base
{
    [CollectionDefinition(nameof(BaseApiTestFixture))]
    public class BaseApiTestCollection : ICollectionFixture<BaseApiTestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    public class BaseApiTestFixture : IDisposable
    {
        public readonly string DefaultRedirectUrl = "https://www.i-synergy.nl";
        public readonly string DefaultWebhookUrl = "https://www.i-synergy.nl/webhook";

        public readonly string ApiTestKey = "test_MhyzSqKSnsxEB5NmBzNeDuVf39ETsa"; // Insert you API key here

        public readonly IPaymentClient PaymentClient;
        public readonly IPaymentMethodClient PaymentMethodClient;
        public readonly IRefundClient RefundClient;
        public readonly IIssuerClient IssuerClient;
        public readonly ISubscriptionClient SubscriptionClient;
        public readonly IMandateClient MandateClient;
        public readonly ICustomerClient CustomerClient;
        public readonly IProfileClient ProfileClient;

        public BaseApiTestFixture()
        {
            EnsureTestApiKey();

            PaymentClient = new PaymentClient(this.ApiTestKey);
            PaymentMethodClient = new PaymentMethodClient(this.ApiTestKey);
            RefundClient = new RefundClient(this.ApiTestKey);
            IssuerClient = new IssuerClient(this.ApiTestKey);
            SubscriptionClient = new SubscriptionClient(this.ApiTestKey);
            MandateClient = new MandateClient(this.ApiTestKey);
            CustomerClient = new CustomerClient(this.ApiTestKey);
            ProfileClient = new ProfileClient(this.ApiTestKey);
        }

        public void Dispose()
        {
        }

        private void EnsureTestApiKey()
        {
            if (String.IsNullOrEmpty(this.ApiTestKey))
            {
                throw new ArgumentException("Please enter you API key in the BaseMollieApiTestClass class");
            }

            if (!this.ApiTestKey.StartsWith("test"))
            {
                throw new ArgumentException("You should not run these tests on your live key!");
            }
        }
    }
}
