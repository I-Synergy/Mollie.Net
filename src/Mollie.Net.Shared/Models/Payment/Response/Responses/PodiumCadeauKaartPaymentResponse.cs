using Mollie.Net.Models.Payment.Response;

namespace Mollie.Net.Models.Payment.Responses.Specific
{
    public class PodiumCadeauKaartPaymentResponse : PaymentResponse {
        public PodiumCadeauKaartPaymentResponseDetails Details { get; set; }
    }
    
    public class PodiumCadeauKaartPaymentResponseDetails {
        /// <summary>
        /// The last four digits of the card number.
        /// </summary>
        public string CardNumber { get; set; }
    }
}
