using Mollie.Net.Models.Base;

namespace Mollie.Net.Models.Issuer
{
    public class IssuerResponse : ModelBase
    {
        /// <summary>
        /// Gets or sets the Id property value.
        /// The issuer's unique identifier, for example ideal_ABNANL2A. When creating a payment, specify this ID as the issuer parameter to forward 
        /// the consumer to their banking environment directly.
        /// </summary>
        public string Id
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Name property value.
        /// The issuer's full name, for example 'ABN AMRO'.
        /// </summary>
        public string Name
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets or sets the Method property value.
        /// The payment method this issuer belongs to. The Issuers API currently only supports iDEAL.
        /// </summary>
        public string Method
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
