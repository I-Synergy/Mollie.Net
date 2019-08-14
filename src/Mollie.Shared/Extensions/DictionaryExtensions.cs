using System.Linq;
using System.Net;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static string ToQueryString(this Dictionary<string, string> parameters)
        {
            if (!parameters.Any())
                return string.Empty;

            return "?" + string.Join("&", parameters.Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(x.Value)}"));
        }

        public static void AddValueIfNotNullOrEmpty(this IDictionary<string, string> dictionary, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dictionary.Add(key, value);
            }
        }
    }
}
