using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request {
    public class IdealPaymentRequest : PaymentRequest {
        public IdealPaymentRequest() {
            this.Method = Enumerations.PaymentMethods.Ideal;
        }

        public string Issuer { get; set; }
    }
}