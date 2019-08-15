using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Organization;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class OrganizationsClient : OauthClientBase, IOrganizationsClient
    {
        public OrganizationsClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<OrganizationResponse> GetCurrentOrganizationAsync() =>
            ClientService.GetAsync<OrganizationResponse>($"organizations/me");

        public Task<OrganizationResponse> GetOrganizationAsync(string organizationId) =>
            ClientService.GetAsync<OrganizationResponse>($"organizations/{organizationId}");

        public Task<ListResponse<OrganizationResponse>> GetOrganizationsListAsync(string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<OrganizationResponse>>("organizations", from, limit, null);

        public Task<OrganizationResponse> GetOrganizationAsync(UrlObjectLink<OrganizationResponse> url) =>
            ClientService.GetAsync(url);
    }
}