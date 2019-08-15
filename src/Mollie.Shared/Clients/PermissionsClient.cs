using System.Threading.Tasks;
using Mollie.Models.List;

using Mollie.Models.Permission;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class PermissionsClient : OauthClientBase, IPermissionsClient
    {
        public PermissionsClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<PermissionResponse> GetPermissionAsync(string permissionId) =>
            ClientService.GetAsync<PermissionResponse>($"permissions/{permissionId}");

        public Task<PermissionResponse> GetPermissionAsync(UrlObjectLink<PermissionResponse> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<PermissionResponse>> GetPermissionListAsync() =>
            ClientService.GetListAsync<ListResponse<PermissionResponse>>("permissions", null, null);
    }
}