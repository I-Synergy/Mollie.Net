using Mollie.Net.Enumerations;
using Mollie.Net.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mollie.Net.Models.Mandate
{
    public class MandateRequest : ModelBase
    {
        /// <summary>
        /// Gets or sets the Method property value.
        /// Optional - Use this parameter to set a wehook URL for this payment only. Mollie will ignore any webhook set in your website profile for this payment.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentMethod Method
        {
            get { return GetValue<PaymentMethod>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the ConsumerName property value.
        /// Required - Name of consumer you add to the mandate
        /// </summary>
        [Required]
        public string ConsumerName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the ConsumerAccount property value.
        /// Required - Consumer's IBAN account
        /// </summary>
        [Required]
        public string ConsumerAccount
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the ConsumerBic property value.
        /// Optional - The consumer's bank's BIC / SWIFT code.
        /// </summary>
        public string ConsumerBic
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the SignatureDate property value.
        /// Optional - The date when the mandate was signed.
        /// </summary>
        public DateTime? SignatureDate
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the MandateReference property value.
        /// Optional - A custom reference
        /// </summary>
        public string MandateReference
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public MandateRequest()
        {
            this.Method = PaymentMethod.DirectDebit;
        }
    }
}
