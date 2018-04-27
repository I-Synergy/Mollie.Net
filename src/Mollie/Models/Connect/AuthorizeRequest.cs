namespace Mollie.Models.Connect {
    public class AuthorizeRequest {
        public string ClientId { get; set; }
        public string RedirectUri { get; set; }
        public string State { get; set; }
        public string Scope { get; set; }
        public string ResponseType { get; set; }
        public string ApprovalPrompt { get; set; }
    }
}