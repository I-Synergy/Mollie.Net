using Mollie.Net.Enumerations;

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
