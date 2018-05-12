using Mollie.Enumerations;

namespace Mollie.Models.Profile.Request
{
    public class ProfileRequest
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public CategoryCode CategoryCode { get; set; }
        public Mode? Mode { get; set; }
    }
}
