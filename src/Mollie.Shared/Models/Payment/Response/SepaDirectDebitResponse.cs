using Mollie.Models.Payment.Response;

namespace Mollie.Models.Payment.Response
{
    public class SepaDirectDebitResponse : PaymentResponse {
        public SepaDirectDebitResponseDetails Details { get; set; }
    }

    public class SepaDirectDebitResponseDetails {
        public string TransferReference { get; set; }
        public string CreditorIdentifier { get; set; }
        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
        public string ConsumerBic { get; set; }
        public string SignatureDate { get; set; }
        public string BankReasonCode { get; set; }
        public string BankReason { get; set; }
        public string EndToEndIdentifier { get; set; }
        public string MandateReference { get; set; }
        public string BatchReference { get; set; }
        public string FileReference { get; set; }
    }
}
