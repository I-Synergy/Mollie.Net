using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Mollie.Extensions
{
    internal static class DictionaryExtensions
    {
        public static string ToQueryString(this Dictionary<string, object> parameters)
        {
            if (!parameters.Any())
                return string.Empty;

            return "?" + string.Join("&", parameters.Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(x.Value.ToString())}"));
        }
    }
}
