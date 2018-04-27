using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mollie.Models.PaymentMethod {
    public class PaymentMethodResponse {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethods Id { get; set; }
        public string Description { get; set; }
        public PaymentMethodResponseAmount Amount { get; set; }
        public PaymentMethodResponseImage Image { get; set; }

        public override string ToString() => this.Description;
    }
}