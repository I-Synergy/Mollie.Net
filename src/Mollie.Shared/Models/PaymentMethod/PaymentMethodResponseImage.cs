namespace Mollie.Models.PaymentMethod {
    public class PaymentMethodResponseImage {
        public string Normal { get; set; }
        public string Bigger { get; set; }
        public override string ToString() => this.Normal;
    }
}