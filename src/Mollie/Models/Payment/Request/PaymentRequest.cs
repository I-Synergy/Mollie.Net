using Mollie.Enumerations;
using Mollie.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mollie.Models.Payment.Request
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumerations.PaymentMethods? Method { get; set; }
        [JsonConverter(typeof(RawJsonConverter))]
        public string Metadata { get; set; }
        public string WebhookUrl { get; set; }
        public string Locale { get; set; }
        public string CustomerId { get; set; }
        public RecurringType? RecurringType { get; set; }
        public string MandateId { get; set; }
        public string ProfileId { get; set; }
        public bool? Testmode { get; set; }
        public PaymentRequestApplicationFee ApplicationFee { get; set; }

        public void SetMetadata(object metadataObj, JsonSerializerSettings jsonSerializerSettings = null)
        {
            this.Metadata = JsonConvert.SerializeObject(metadataObj, jsonSerializerSettings);
        }

        public override string ToString() => $"Method: {this.Method} - Amount: {this.Amount}";
    }
}