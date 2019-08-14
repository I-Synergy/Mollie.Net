﻿using Mollie.Enumerations;

namespace Mollie.Models.Settlement
{
    public class SettlementPeriodRevenue
    {
        /// <summary>
        /// A description of the subtotal.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The net total of received funds for this payment method (excludes VAT).
        /// </summary>
        public Amount AmountNet { get; set; }

        /// <summary>
        /// The VAT amount applicable to the revenue.
        /// </summary>
        public Amount AmountVat { get; set; }

        /// <summary>
        /// The gross total of received funds for this payment method (includes VAT).
        /// </summary>
        public Amount AmountGross { get; set; }

        /// <summary>
        /// The number of times costs were made for this payment method.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The payment method ID, if applicable.
        /// </summary>
        public PaymentMethods? Method { get; set; }
    }
}