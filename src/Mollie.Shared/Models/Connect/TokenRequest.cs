namespace Mollie.Models.Connect {
    public class TokenRequest
    {
        public TokenRequest(string code, string redirectUri)
        {
            if (code.StartsWith("refresh_"))
            {
                this.GrantType = "refresh_token";
                this.RefreshToken = code;
            }
            else
            {
                this.GrantType = "authorization_code";
                this.Code = code;
            }

            this.RedirectUri = redirectUri;
        }

        public string GrantType { get; }
        public string Code { get; }
        public string RefreshToken { get; }
        public string RedirectUri { get; }
    }
}