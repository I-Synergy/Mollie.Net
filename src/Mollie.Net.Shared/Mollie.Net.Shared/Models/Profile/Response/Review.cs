using Mollie.Net.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Net.Models.Profile.Response
{
    public class Review
    {
        /// <summary>
        /// The status of the requested profile changes.
        /// </summary>
        public ReviewStatus Status { get; set; }
    }
}
