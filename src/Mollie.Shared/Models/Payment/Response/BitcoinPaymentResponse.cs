namespace Mollie.Models.Payment.Response
{
    public class BitcoinPaymentResponse : PaymentResponse {
        public BitcoinPaymentResponseDetails Details { get; set; }
    }

    public class BitcoinPaymentResponseDetails {
        public string BitcoinAddress { get; set; }
        public string BitcoinAmount { get; set; }
        public string BitcoinRate { get; set; }
        public string BitcoinUri { get; set; }
        public QrCode QrCode { get; set; }
    }
}