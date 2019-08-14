namespace Mollie.Models.PaymentMethod
{
    public class PaymentMethodResponseAmount
    {
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }

        public override string ToString() => $"Minimum: {Minimum} - Maximum: {Maximum}";
    }
}