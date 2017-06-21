using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Net.Models.Profile.Response
{
    public class Links
    {
        /// <summary>
        /// The URL to the nested API keys resource.
        /// </summary>
        public string Apikeys { get; set; }

        /// <summary>
        /// The Checkout preview URL. You need to be logged in to access this page.
        /// </summary>
        public string CheckoutPreviewUrl { get; set; }
    }
}
