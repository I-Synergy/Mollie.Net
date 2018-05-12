namespace Mollie.Models.Payment.Response
{
    public class PayPalPaymentResponse : PaymentResponse {
        public PayPalPaymentResponseDetails Details { get; set; }
    }

    public class PayPalPaymentResponseDetails {
        public string ConsumerName { get; set; }
        public string PayPalReference { get; set; }
        public string ConsumerAccount { get; set; }
    }
}