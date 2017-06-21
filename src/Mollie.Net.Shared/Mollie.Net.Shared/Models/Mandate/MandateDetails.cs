using Mollie.Net.Models.Base;


namespace Mollie.Net.Models.Mandate
{
    public class MandateDetails : ModelBase
    {
        /// <summary>
        /// The direct debit account holder's name.
        /// </summary>
        public string ConsumerName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The direct debit account IBAN.
        /// </summary>
        public string ConsumerAccount
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The direct debit account BIC.
        /// </summary>
        public string ConsumerBic
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The credit card holder's name.
        /// </summary>
        public string CardHolder
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The last four digits of the credit card number.
        /// </summary>
        public string CardNumber
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// The credit card's label. Note that not all labels can be acquired through Mollie.
        /// </summary>
        public string CardLabel
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Unique alphanumeric representation of credit card, usable for identifying returning customers.
        /// </summary>
        public string CardFingerprint
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        /// <summary>
        /// Expiry date of the credit card card in YYYY-MM-DD format.
        /// </summary>
        public string CardExpiryDate
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
