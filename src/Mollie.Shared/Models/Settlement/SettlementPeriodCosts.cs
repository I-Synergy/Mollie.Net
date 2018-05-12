using Mollie.Enumerations;

namespace Mollie.Models.Settlement
{
	public class SettlementPeriodCosts
	{
		public string Description { get; set; }
		public SettlementAmount Amount { get; set; }
		public int Count { get; set; }
		public SettlementPeriodCostsRate Rate { get; set; }
		public PaymentMethods Method { get; set; }
	}
}