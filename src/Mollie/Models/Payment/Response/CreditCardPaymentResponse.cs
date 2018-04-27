using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Mollie.Models.Payment.Response;
using Mollie.Enumerations;

namespace Mollie.Models.Payment.Response
{
    public class CreditCardPaymentResponse : PaymentResponse {
        public CreditCardPaymentResponseDetails Details { get; set; }
    }

    public class CreditCardPaymentResponseDetails {
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CreditCardAudience? CardAudience { get; set; }
        public CreditCardLabel? CardLabel { get; set; }
        public string CardCountry { get; set; }
        public string CardCountryCode { get; set; }
        public string CardSecurity { get; set; }
        public string FeeRegion { get; set; }
    }
}