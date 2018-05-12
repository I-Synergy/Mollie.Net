using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mollie.Models.Subscription
{
    public class SubscriptionResponse
    {
        public string Resource { get; set; }
        public string Id { get; set; }
        public string CustomerId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Mode Mode { get; set; }
        public DateTime CreatedDatetime { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionStatus Status { get; set; }
        public decimal Amount { get; set; }
        public int? Times { get; set; }
        public string Interval { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethods Method { get; set; }
        public DateTime? CancelledDateTime { get; set; }
        public SubscriptionResponseLinks Links { get; set; }
    }
}
