namespace Mollie.Models.Error
{
    public class MollieErrorMessage
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Detail}";
        }
    }
}