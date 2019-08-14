using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request
{
    public class PayPalPaymentRequest : PaymentRequest
    {
        public PayPalPaymentRequest()
        {
            Method = PaymentMethods.PayPal;
        }

        public AddressObject ShippingAddress { get; set; }
    }
}