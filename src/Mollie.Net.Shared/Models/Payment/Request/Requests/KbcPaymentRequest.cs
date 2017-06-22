using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Request;

namespace Mollie.Net.Models.Payment.Requests {
    public class KbcPaymentRequest : PaymentRequest {
        public KbcIssuer Issuer { get; set; }
    }
}
