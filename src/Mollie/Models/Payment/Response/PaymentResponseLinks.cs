namespace Mollie.Models.Payment.Response
{
    public class PaymentResponseLinks
    {
        public string PaymentUrl { get; set; }
        public string WebhookUrl { get; set; }
        public string RedirectUrl { get; set; }
        public string Settlement { get; set; }
    }
}
