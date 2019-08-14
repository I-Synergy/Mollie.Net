using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request
{
    public class PaySafeCardPaymentRequest : PaymentRequest
    {
        public PaySafeCardPaymentRequest()
        {
            Method = PaymentMethods.PaySafeCard;
        }

        /// <summary>
        /// Used for consumer identification. For example, you could use the consumer’s IP address.
        /// </summary>
        public string CustomerReference { get; set; }
    }
}