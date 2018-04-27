using System;
using Newtonsoft.Json;

namespace Mollie.Models.Chargeback
{
    public class ChargebackResponse
    {
		public string Id { get; set; }
		[JsonProperty(PropertyName = "payment")]
		public string PaymentId { get; set; }
		public string Payment { get; set; }
		public decimal Amount { get; set; }
		public DateTime ChargebackDatetime { get; set; }
		public DateTime? ReversedDatetime { get; set; }
    }
}
