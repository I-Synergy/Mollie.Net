using System;

namespace Mollie.Models.Organization
{
    public class OrganizationResponse
    {
        public string Resource { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime RegistrationDatetime { get; set; }
        public DateTime VerifiedDatetime { get; set; }
    }
}