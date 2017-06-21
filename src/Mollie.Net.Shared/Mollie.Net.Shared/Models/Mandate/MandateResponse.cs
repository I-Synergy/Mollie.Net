using Mollie.Net.Enumerations;
using Mollie.Net.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Net.Models.Mandate
{
    public class MandateResponse : ModelBase
    {
        /// <summary>
        /// Unique identifier of you mandate.
        /// </summary>
        public string Id
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Current status of mandate.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public MandateStatus Status
        {
            get { return GetValue<MandateStatus>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// DateTime when mandate was created.
        /// </summary>
        public DateTime? CreatedDatetime
        {
            get { return GetValue<DateTime?>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Payment method of the mandate.
        /// </summary>
        public PaymentMethod Method
        {
            get { return GetValue<PaymentMethod>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The customer's unique identifier, for example cst_3RkSN1zuPE.
        /// </summary>
        public string CustomerId
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Mandate details that are different per payment method. Available fields depend on that payment method.
        /// </summary>
        public MandateDetails Details
        {
            get { return GetValue<MandateDetails>(); }
            set { SetValue(value); }
        }
    }
}
