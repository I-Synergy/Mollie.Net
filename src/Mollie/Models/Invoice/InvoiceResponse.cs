using System;
using System.Collections.Generic;
using Mollie.Enumerations;
using Mollie.Models.Settlement;

namespace Mollie.Models.Invoice
{
	public class InvoiceResponse
	{
		public string Id { get; set; }
		public string Reference { get; set; }
		public string VatNumber { get; set; }
		public InvoiceStatus Status { get; set; }
		public DateTime IssueDate { get; set; }
		public DateTime? PaidDate { get; set; }
		public DateTime? DueDate { get; set; }
		public InvoiceAmount Amount { get; set; }
		public List<InvoiceLine> Lines { get; set; }
		public List<SettlementResponse> Settlements { get; set; }
		public InvoiceLinks Links { get; set; }
	}
}