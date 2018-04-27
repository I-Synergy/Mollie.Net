using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request {
    public class SepaDirectDebitRequest : PaymentRequest {
        public SepaDirectDebitRequest() {
            this.Method = Enumerations.PaymentMethods.DirectDebit;
        }

        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
    }
}