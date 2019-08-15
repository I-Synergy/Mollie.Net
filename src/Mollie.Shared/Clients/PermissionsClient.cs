using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;

using Mollie.Models.Permission;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class PermissionsClient : OauthClientBase, IPermissionsClient
    {
        public PermissionsClient(string oauthAccessToken, HttpClient httpClient = null) : base(oauthAccessToken, httpClient)
        {
        }

        public Task<PermissionResponse> GetPermissionAsync(string permissionId) =>
            GetAsync<PermissionResponse>($"permissions/{permissionId}");

        public Task<PermissionResponse> GetPermissionAsync(UrlObjectLink<PermissionResponse> url) =>
            GetAsync(url);

        public Task<ListResponse<PermissionResponse>> GetPermissionListAsync() =>
            GetListAsync<ListResponse<PermissionResponse>>("permissions", null, null);
    }
}