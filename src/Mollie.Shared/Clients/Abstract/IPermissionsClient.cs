using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Permission;
using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface IPermissionsClient
    {
        Task<PermissionResponse> GetPermissionAsync(string permissionId);
        Task<PermissionResponse> GetPermissionAsync(UrlObjectLink<PermissionResponse> url);
        Task<ListResponse<PermissionResponse>> GetPermissionListAsync();
    }
}