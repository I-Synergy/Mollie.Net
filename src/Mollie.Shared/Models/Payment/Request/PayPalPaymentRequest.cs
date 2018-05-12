using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request {
    public class PayPalPaymentRequest : PaymentRequest {
        public PayPalPaymentRequest() {
            this.Method = Enumerations.PaymentMethods.PayPal;
        }

        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingRegion { get; set; }
        public string ShippingPostal { get; set; }
        public string ShippingCountry { get; set; }
    }
}