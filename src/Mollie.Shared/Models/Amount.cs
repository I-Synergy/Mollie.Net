﻿namespace Mollie.Models
{
    public class Amount
    {
        /// <summary>
        /// An ISO 4217 currency code. The currencies supported depend on the payment methods that are enabled on your account.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// An ISO 4217 currency code. The currencies supported depend on the payment methods that are enabled on your account.
        /// </summary>
        public string Value { get; set; }

        public Amount(string currency, string value)
        {
            Currency = currency;
            Value = value;
        }

        public Amount() { }

        public override string ToString()
        {
            return $"{Value} {Currency}";
        }
    }
}