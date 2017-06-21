using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Response;

namespace Mollie.Net.Models.Payment.Responses {
    public class PaySafeCardPaymentResponse : PaymentResponse {
        public PaySafeCardPaymentResponseDetails Details { get; set; }
    }

    public class PaySafeCardPaymentResponseDetails {
        /// <summary>
        /// The consumer identification supplied when the payment was created.
        /// </summary>
        public string CustomerReference { get; set; }
    }
}