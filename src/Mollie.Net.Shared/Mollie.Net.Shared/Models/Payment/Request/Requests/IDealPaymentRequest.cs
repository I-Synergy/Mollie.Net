using Mollie.Net.Enumerations;
using Mollie.Net.Models.Payment.Request;

namespace Mollie.Net.Models.Payment.Requests {
    public class IdealPaymentRequest : PaymentRequest {
        /// <summary>
        /// (Optional) iDEAL issuer id. The id could for example be ideal_INGBNL2A. The returned paymentUrl will then directly point to the ING web site.
        /// </summary>
        public string Issuer { get; set; }

        public IdealPaymentRequest() {
            this.Method = PaymentMethod.Ideal;
        }
    }
}