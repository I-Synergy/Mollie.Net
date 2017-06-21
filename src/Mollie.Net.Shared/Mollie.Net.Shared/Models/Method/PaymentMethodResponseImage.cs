using System;
using System.Collections.Generic;
using System.Text;

namespace Mollie.Net.Models.Payment.Method
{
    /// <summary>
    /// URLs of images representing the payment method.
    /// </summary>
    public class PaymentMethodResponseImage
    {
        /// <summary>
        /// The URL for a payment method icon of 40x40 pixels.
        /// </summary>
        public string Normal { get; set; }

        /// <summary>
        /// The URL for a payment method icon of 80x80 pixels.
        /// </summary>
        public string Bigger { get; set; }

        public override string ToString()
        {
            return this.Normal;
        }
    }
}
