namespace Mollie.Models.Payment.Response
{
    public class BankTransferPaymentResponse : PaymentResponse {
        public BankTransferPaymentResponseDetails Details { get; set; }
    }

    public class BankTransferPaymentResponseDetails {
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public string BankBic { get; set; }
        public string TransferReference { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
        public string ConsumerBic { get; set; }
        public QrCode QrCode { get; set; }
    }
}