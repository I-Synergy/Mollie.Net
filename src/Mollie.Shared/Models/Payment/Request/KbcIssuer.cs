using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mollie.Models.Payment.Request {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum KbcIssuer {
        [EnumMember(Value = "kbc")] Kbc,
        [EnumMember(Value = "cbc")] Cbc
    }
}