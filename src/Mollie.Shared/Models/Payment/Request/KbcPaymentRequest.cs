﻿using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request
{
    public class KbcPaymentRequest : PaymentRequest
    {
        public KbcPaymentRequest()
        {
            Method = PaymentMethods.Kbc;
        }

        /// <summary>
        /// The issuer to use for the KBC/CBC payment. These issuers are not dynamically available through the Issuers API, 
        /// but can be retrieved by using the issuers include in the Methods API.
        /// </summary>
        public KbcIssuer Issuer { get; set; }
    }
}