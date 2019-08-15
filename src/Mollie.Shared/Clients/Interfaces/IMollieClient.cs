namespace Mollie.Client
{
    public interface IMollieClient : ICustomerClient, IMandateClient, IPaymentClient, IPaymentMethodClient, IRefundClient, ISubscriptionClient
    {
    }
}