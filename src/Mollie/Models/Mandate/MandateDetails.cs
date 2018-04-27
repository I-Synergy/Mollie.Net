namespace Mollie.Models.Mandate
{
    public class MandateDetails
    {
        public string ConsumerName { get; set; }
        public string ConsumerAccount { get; set; }
        public string ConsumerBic { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string CardLabel { get; set; }
        public string CardFingerprint { get; set; }
        public string CardExpiryDate { get; set; }
    }
}
