using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mollie.Sample.Framework.Extensions
{
    public static class ConfigurationBinderExtensions
    {
        public static void BindWithReload(this IConfiguration configuration, object instance)
        {
            configuration.Bind(instance);
            configuration.GetReloadToken().RegisterChangeCallback((_) => configuration.Bind(instance), null);
        }
    }
}
