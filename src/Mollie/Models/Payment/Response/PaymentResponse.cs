using Mollie.Enumerations;
using Mollie.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mollie.Models.Payment.Response
{
    public class PaymentResponse
    {
        public string Id { get; set; }
        public PaymentMode Mode { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentStatus? Status { get; set; }
        public DateTime? PaidDatetime { get; set; }
        public DateTime? CancelledDatetime { get; set; }
        public DateTime? ExpiredDatetime { get; set; }
        public string ExpiryPeriod { get; set; }
        public decimal Amount { get; set; }
        public decimal? AmountRefunded { get; set; }
        public decimal? AmountRemaining { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethods? Method { get; set; }
        [JsonConverter(typeof(RawJsonConverter))]
        public string Metadata { get; set; }
        public string Locale { get; set; }
        public string ProfileId { get; set; }
        public string SettlementId { get; set; }
        public string CustomerId { get; set; }
        public RecurringType? RecurringType { get; set; }
        public PaymentResponseLinks Links { get; set; }
        public string MandateId { get; set; }
        public string SubscriptionId { get; set; }

        public T GetMetadata<T>(JsonSerializerSettings jsonSerializerSettings = null) =>
           JsonConvert.DeserializeObject<T>(this.Metadata, jsonSerializerSettings);

        public override string ToString() =>
            $"Id: {this.Id} - Status: {this.Status} - Method: {this.Method} - Amount: {this.Amount}";
    }
}
