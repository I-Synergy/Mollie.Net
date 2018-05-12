using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mollie.Models.Subscription
{
    public class SubscriptionRequest
    {
        public decimal Amount { get; set; }
        public int? Times { get; set; }
        public string Interval { get; set; }
        public DateTime? StartDate { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enumerations.PaymentMethods? Method { get; set; }
        public string WebhookUrl { get; set; }
    }
}
