
namespace Mollie.Models.Payment.Response
{
    public class PodiumCadeauKaartPaymentResponse : PaymentResponse {
        public PodiumCadeauKaartPaymentResponseDetails Details { get; set; }
    }
    
    public class PodiumCadeauKaartPaymentResponseDetails {
        public string CardNumber { get; set; }
    }
}
