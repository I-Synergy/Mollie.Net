﻿using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Response;

namespace Mollie.Net.Models.Payment.Responses {
    public class IdealPaymentResponse : PaymentResponse {
        /// <summary>
        /// An object with the consumer bank account details.
        /// </summary>
        public IdealPaymentResponseDetails Details { get; set; }
    }

    public class IdealPaymentResponseDetails {
        /// <summary>
        /// Only available if the payment has been completed – The consumer's name.
        /// </summary>
        public string ConsumerName { get; set; }

        /// <summary>
        /// Only available if the payment has been completed – The consumer's IBAN.
        /// </summary>
        public string ConsumerAccount { get; set; }

        /// <summary>
        /// Only available if the payment has been completed – The consumer's bank's BIC.
        /// </summary>
        public string ConsumerBic { get; set; }
    }
}