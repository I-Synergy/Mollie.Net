using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Organization;
using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface IOrganizationsClient
    {
        Task<OrganizationResponse> GetCurrentOrganizationAsync();
        Task<OrganizationResponse> GetOrganizationAsync(string organizationId);
        Task<ListResponse<OrganizationResponse>> GetOrganizationsListAsync(string from = null, int? limit = null);
        Task<OrganizationResponse> GetOrganizationAsync(UrlObjectLink<OrganizationResponse> url);
    }
}