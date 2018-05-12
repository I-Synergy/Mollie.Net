using System;

namespace Mollie.Models.Invoice
{
	public class InvoiceLine
	{
		public DateTime Period { get; set; }
		public string Description { get; set; }
		public int Count { get; set; }
		public decimal VatPercentage { get; set; }
		public decimal Amount { get; set; }
	}
}