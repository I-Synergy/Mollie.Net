namespace Mollie.Models.Customer
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }
        public string Metadata { get; set; }
    }
}
