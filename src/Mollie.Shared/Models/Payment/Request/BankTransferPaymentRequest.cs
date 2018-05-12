using Mollie.Enumerations;

namespace Mollie.Models.Payment.Request {
    public class BankTransferPaymentRequest : PaymentRequest {
        public BankTransferPaymentRequest() {
            this.Method = Enumerations.PaymentMethods.BankTransfer;
        }

        public string BillingEmail { get; set; }
        public string DueDate { get; set; }
    }
}