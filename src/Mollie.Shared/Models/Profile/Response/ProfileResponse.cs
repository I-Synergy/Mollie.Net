using Mollie.Enumerations;
using System;

namespace Mollie.Models.Profile.Response
{
    public class ProfileResponse
    {
        public string Id { get; set; }
        public Mode Mode { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CategoryCode CategoryCode { get; set; }
        public ProfileStatus Status { get; set; }
        public Review Review { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public DateTime UpdatedDatetime { get; set; }
        public Links Links { get; set; }
    }
}
