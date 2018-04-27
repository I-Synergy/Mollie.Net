using System.Collections.Generic;

namespace Mollie.Models.Settlement
{
	public class SettlementPeriod
	{
		public List<SettlementPeriodRevenue> Revenue { get; set; }
		public List<SettlementPeriodCosts> Costs { get; set; }
	}
}