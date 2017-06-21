using Mollie.Net.Enumerations;
using Mollie.Net.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mollie.Net.Models.Customer
{
    public class CustomerResponse : ModelBase
    {
        /// <summary>
        /// Gets or sets the Id property value.
        /// The customer's unique identifier, for example cst_4pmbK7CqtT. 
        /// Store this identifier for later recurring payments.
        /// </summary>
        public string Id
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Mode property value.
        /// The mode used to create this payment. Mode determines whether a payment is real or a test payment.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMode Mode
        {
            get { return GetValue<PaymentMode>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Name property value.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Email property value.
        /// </summary>
        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Metadata property value.
        /// Optional metadata.
        /// Use this if you want Mollie to store additional info.
        /// </summary>
        public string Metadata
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }


    }
}
