using Mollie.Net.Models.Payment.Response;

namespace Mollie.Net.Models.Payment.Responses
{
    public class MisterCashPaymentResponse : PaymentResponse {
        public MisterCashPaymentResponseDetails Details { get; set; }
    }

    public class MisterCashPaymentResponseDetails {
        public string CardNumber { get; set; }
    }
}