using Mollie.Client.Abstract;

namespace Mollie.Abstract
{
    public interface IMollieClient : ICustomerClient, IMandateClient, IPaymentClient, IPaymentMethodClient, IRefundClient, ISubscriptionClient
    {
    }
}