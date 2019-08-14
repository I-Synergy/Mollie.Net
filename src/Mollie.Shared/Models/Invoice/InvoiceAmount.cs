namespace Mollie.Models.Invoice
{
    public class InvoiceAmount
    {
        public decimal Net { get; set; }
        public decimal Vat { get; set; }
        public decimal Gross { get; set; }
    }
}