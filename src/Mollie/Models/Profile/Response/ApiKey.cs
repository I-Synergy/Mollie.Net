using System;

namespace Mollie.Models.Profile.Response
{
    public class ApiKey
    {
        public string Resource { get; set; }
        public string Id { get; set; }
        public string Key { get; set; }
        public DateTime CreatedDatetime { get; set; }
    }
}
