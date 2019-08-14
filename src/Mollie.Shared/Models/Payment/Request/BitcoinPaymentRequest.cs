using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request
{
    public class BitcoinPaymentRequest : PaymentRequest
    {
        public BitcoinPaymentRequest()
        {
            Method = PaymentMethods.Bitcoin;
        }

        /// <summary>
        /// The email address of the customer. This is used when handling invalid transactions (wrong amount 
        /// transferred, transfer of expired or canceled payments, et cetera).
        /// </summary>
        public string BillingEmail { get; set; }
    }
}