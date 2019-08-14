using Mollie.Client;
using Mollie.Client.Abstract;
using System;

namespace Mollie.Tests.Api
{
    public class BaseApiTestFixture : IDisposable
    {
        public readonly string DefaultRedirectUrl = "https://www.i-synergy.nl";
        public readonly string DefaultWebhookUrl = "https://www.i-synergy.nl/webhook";

        public readonly string ApiTestKey = "test_yGJ4USbh3BWV5AkGbdh4NG4EG2UdaF"; // Insert you API key here

        public readonly IPaymentClient PaymentClient;
        public readonly IPaymentMethodClient PaymentMethodClient;
        public readonly IRefundClient RefundClient;
        public readonly ISubscriptionClient SubscriptionClient;
        public readonly IMandateClient MandateClient;
        public readonly ICustomerClient CustomerClient;
        public readonly IProfileClient ProfileClient;
        public readonly IOrderClient OrderClient;

        public BaseApiTestFixture()
        {
            EnsureTestApiKey();

            PaymentClient = new PaymentClient(ApiTestKey);
            PaymentMethodClient = new PaymentMethodClient(ApiTestKey);
            RefundClient = new RefundClient(ApiTestKey);
            SubscriptionClient = new SubscriptionClient(ApiTestKey);
            MandateClient = new MandateClient(ApiTestKey);
            CustomerClient = new CustomerClient(ApiTestKey);
            ProfileClient = new ProfileClient(ApiTestKey);
            OrderClient = new OrderClient(ApiTestKey);
        }

        public void Dispose()
        {
        }

        private void EnsureTestApiKey()
        {
            if (string.IsNullOrEmpty(ApiTestKey))
            {
                throw new ArgumentException("Please enter you API key in the BaseMollieApiTestClass class");
            }

            if (!ApiTestKey.StartsWith("test"))
            {
                throw new ArgumentException("You should not run these tests on your live key!");
            }
        }
    }
}
