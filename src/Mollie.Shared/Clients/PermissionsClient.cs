using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<PermissionResponse> GetPermissionAsync(string permissionId)
        {
            return await GetAsync<PermissionResponse>($"permissions/{permissionId}").ConfigureAwait(false);
        }

        public async Task<PermissionResponse> GetPermissionAsync(UrlObjectLink<PermissionResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<ListResponse<PermissionResponse>> GetPermissionListAsync()
        {
            return await GetListAsync<ListResponse<PermissionResponse>>("permissions", null, null).ConfigureAwait(false);
        }
    }
}