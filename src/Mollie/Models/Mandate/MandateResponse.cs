using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mollie.Models.Mandate
{
    public class MandateResponse
    {
        public string Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MandateStatus Status { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public PaymentMethods Method { get; set; }
        public string CustomerId { get; set; }
        public MandateDetails Details { get; set; }
    }
}
