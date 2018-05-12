using System.Collections.Generic;
using System.Threading.Tasks;
using Mollie.Models.Connect;

namespace Mollie.Abstract {
    public interface IConnectClient {
        string GetAuthorizationUrl(string state, List<string> scopes, string redirectUri = null, bool forceApprovalPrompt = false);
        Task<TokenResponse> GetAccessTokenAsync(TokenRequest request);
    }
}