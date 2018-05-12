using Mollie.Enumerations;
using System;
using System.Collections.Generic;

namespace Mollie.Models.Settlement
{
	public class SettlementResponse
	{
		public string Id { get; set; }
		public string Reference { get; set; }
		public DateTime? CreatedDatetime { get; set; }
		public DateTime? SettledDatetime { get; set; }
		public SettlementStatus Status { get; set; }
		public decimal Amount { get; set; }
		public Dictionary<int, Dictionary<int, SettlementPeriod>> Periods { get; set; }
		public List<string> PaymentIds { get; set; }
		public List<string> RefundIds { get; set; }
		public List<string> ChargebackIds { get; set; }
	}
}