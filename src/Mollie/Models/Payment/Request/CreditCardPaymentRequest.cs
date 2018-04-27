using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request {
    public class CreditCardPaymentRequest : PaymentRequest {
        public CreditCardPaymentRequest() {
            this.Method = Enumerations.PaymentMethods.CreditCard;
        }

        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingRegion { get; set; }
        public string BillingPostal { get; set; }
        public string BillingCountry { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingRegion { get; set; }
        public string ShippingPostal { get; set; }
        public string ShippingCountry { get; set; }
    }
}