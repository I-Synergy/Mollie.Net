﻿namespace Mollie.Models.PaymentMethod.Pricing
{
    public class PricingResponse : IResponseObject
    {
        /// <summary>
        /// The area or product-type where the pricing is applied for, translated in the optional locale passed.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The fixed price per transaction
        /// </summary>
        public FixedPricingResponse Fixed { get; set; }

        /// <summary>
        /// A string containing the percentage what will be charged over the payment amount besides the fixed price.
        /// </summary>
        public decimal Variable { get; set; }
    }
}