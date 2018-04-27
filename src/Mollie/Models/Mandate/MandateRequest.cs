using Mollie.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mollie.Models.Mandate
{
    public class MandateRequest
    {
        public MandateRequest()
        {
            this.Method = PaymentMethods.DirectDebit;
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethods Method { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
        public string ConsumerBic { get; set; }
        public DateTime? SignatureDate { get; set; }
        public string MandateReference { get; set; }
    }
}
