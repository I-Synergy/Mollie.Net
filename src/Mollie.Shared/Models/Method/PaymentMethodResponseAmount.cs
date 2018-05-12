namespace Mollie.Models.Payment.Method
{
    /// <summary>
    /// The minimum and maximum allowed payment amount will differ between payment methods.
    /// </summary>
    public class PaymentMethodResponseAmount
    {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public override string ToString() => $"Minimum: {this.Minimum} - Maximum: {this.Maximum}";
    }
}
