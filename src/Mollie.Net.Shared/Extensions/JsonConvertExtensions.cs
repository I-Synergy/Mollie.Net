using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mollie.Net.Converters
{
    public static class JsonConvertExtensions
    {
        public static string SerializeObjectCamelCase(object value)
        {
            return JsonConvert.SerializeObject(value,
                new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd",
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
}
