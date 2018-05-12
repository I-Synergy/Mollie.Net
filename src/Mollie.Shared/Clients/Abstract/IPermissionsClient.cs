using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Permission;

namespace Mollie.Abstract {
    public interface IPermissionsClient {
        Task<PermissionResponse> GetPermissionAsync(string permissionId);
        Task<ListResponse<PermissionResponse>> GetPermissionListAsync(int? offset = null, int? count = null);
    }
}