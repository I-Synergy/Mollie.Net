﻿using Mollie.Models.Customer;
using Mollie.Models.Url;

namespace Mollie.Models.Mandate
{
    public class MandateResponseLinks
    {
        /// <summary>
        /// The API resource URL of the mandate itself.
        /// </summary>
        public UrlObjectLink<MandateResponse> Self { get; set; }

        /// <summary>
        /// The API resource URL of the customer the mandate is for.
        /// </summary>
        public UrlObjectLink<CustomerResponse> Customer { get; set; }

        /// <summary>
        /// The URL to the mandate retrieval endpoint documentation.
        /// </summary>
        public UrlLink Documentation { get; set; }
    }
}