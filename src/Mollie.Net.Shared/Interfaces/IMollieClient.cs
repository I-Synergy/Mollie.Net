namespace Mollie.Net.Interfaces
{
    public interface IMollieClient : ICustomerClient, IIssuerClient, IMandateClient, IPaymentClient, IPaymentMethodClient, IRefundClient, ISubscriptionClient
    {
    }
}
