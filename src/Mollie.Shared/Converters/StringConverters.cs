using System;
using System.Collections.Generic;

namespace Mollie.Converters
{
    public static class StringConverters
    {
        public static string BuildListQueryString(string from, int? limit, IDictionary<string, string> otherParameters = null)
        {
            Dictionary<string, string> queryParameters = new Dictionary<string, string>();
            queryParameters.AddValueIfNotNullOrEmpty(nameof(from), from);
            queryParameters.AddValueIfNotNullOrEmpty(nameof(limit), Convert.ToString(limit));

            if (otherParameters != null)
            {
                foreach (var parameter in otherParameters)
                {
                    queryParameters.AddValueIfNotNullOrEmpty(parameter.Key, parameter.Value);
                }
            }

            return queryParameters.ToQueryString();
        }
    }
}
