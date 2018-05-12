using System.Threading.Tasks;
using Mollie.Models.Organization;

namespace Mollie.Abstract {
    public interface IOrganizationsClient
    {
        Task<OrganizationResponse> GetOrganizationAsync(string organizationId);
    }
}