using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request
{
    public class Przelewy24PaymentRequest : PaymentRequest
    {
        public Przelewy24PaymentRequest()
        {
            Method = PaymentMethods.Przelewy24;
        }

        /// <summary>
        /// Consumerís email address, this is required for Przelewy24 payments.
        /// </summary>
        public string BillingEmail { get; set; }
    }
}