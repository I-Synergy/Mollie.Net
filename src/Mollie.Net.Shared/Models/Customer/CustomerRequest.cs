using Mollie.Net.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mollie.Net.Models.Customer
{
    public class CustomerRequest : ModelBase
    {
        /// <summary>
        /// Gets or sets the Name property value.
        /// </summary>
        [Required]
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Email property value.
        /// </summary>
        [Required]
        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Locale property value.
        /// Optional - Allow you to preset the language to be used in the payment screens shown to the consumer. When this parameter is not 
        /// provided, the browser language will be used instead (which is usually more accurate). The input formats are: en (language) or 
        /// en_US (language and region).
        /// </summary>
        public string Locale
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Metadata property value.
        /// Optional - Provide any data you like in JSON notation, and we will save the data alongside the customer. Whenever you fetch the 
        /// customer with our API, we'll also include the metadata. You can use up to 1kB of JSON.
        /// </summary>
        public string Metadata
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
