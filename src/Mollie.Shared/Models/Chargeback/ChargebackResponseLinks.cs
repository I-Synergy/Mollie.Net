﻿using Mollie.Models.Payment.Response;
using Mollie.Models.Settlement;
using Mollie.Models.Url;

namespace Mollie.Models.Chargeback
{
    public class ChargebackResponseLinks
    {
        /// <summary>
        /// The API resource URL of the chargeback itself.
        /// </summary>
        public UrlObjectLink<ChargebackResponse> Self { get; set; }

        /// <summary>
        /// The API resource URL of the payment this chargeback belongs to.
        /// </summary>
        public UrlObjectLink<PaymentResponse> Payment { get; set; }

        /// <summary>
        /// The API resource URL of the settlement this payment has been settled with. Not present if not yet settled.
        /// </summary>
        public UrlObjectLink<SettlementResponse> Settlement { get; set; }

        /// <summary>
        /// The URL to the chargeback retrieval endpoint documentation.
        /// </summary>
        public UrlLink Documentation { get; set; }
    }
}