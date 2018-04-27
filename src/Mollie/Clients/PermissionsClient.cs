using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.List;
using Mollie.Models.Permission;
using Mollie.Client.Base;

namespace Mollie.Client {
    public class PermissionsClient : OAuthClientBase, IPermissionsClient {
        public PermissionsClient(string oauthAccessToken) : base(oauthAccessToken) {
        }

        public Task<PermissionResponse> GetPermissionAsync(string permissionId) =>
            GetAsync<PermissionResponse>($"permissions/{permissionId}");

        public Task<ListResponse<PermissionResponse>> GetPermissionListAsync(int? offset = null,
            int? count = null) =>
            GetListAsync<ListResponse<PermissionResponse>>("permissions", offset, count);
    }
}