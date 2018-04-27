namespace Mollie.Models.Payment.Response
{
    public class QrCode
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Src { get; set; }
    }
}
