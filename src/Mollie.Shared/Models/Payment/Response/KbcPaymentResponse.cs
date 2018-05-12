namespace Mollie.Models.Payment.Response
{
    public class KbcPaymentResponse : PaymentResponse {
        public KbcPaymentResponseDetails Details { get; set; }
    }

    public class KbcPaymentResponseDetails {
        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
        public string ConsumerBic { get; set; }
    }
}
