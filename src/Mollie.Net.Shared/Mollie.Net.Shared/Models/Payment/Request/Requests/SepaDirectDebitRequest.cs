using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Request;

namespace Mollie.Net.Models.Payment.Requests {
    public class SepaDirectDebitRequest : PaymentRequest {
        /// <summary>
        /// Optional - Beneficiary name of the account holder.
        /// </summary>
        public string ConsumerName { get; set; }
        /// <summary>
        /// Optional - IBAN of the account holder.
        /// </summary>
        public string ConsumerAccount { get; set; }

        public SepaDirectDebitRequest() {
            this.Method = PaymentMethod.DirectDebit;
        }
    }
}