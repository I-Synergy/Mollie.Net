namespace Mollie.Models.PaymentMethod {
    public class PaymentMethodResponseAmount {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }

        public override string ToString() => $"Minimum: {this.Minimum} - Maximum: {this.Maximum}";
    }
}