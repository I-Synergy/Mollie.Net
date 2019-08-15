using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Organization;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class OrganizationsClient : OauthClientBase, IOrganizationsClient
    {
        public OrganizationsClient(string oauthAccessToken, HttpClient httpClient = null) : base(oauthAccessToken, httpClient)
        {
        }

        public Task<OrganizationResponse> GetCurrentOrganizationAsync() =>
            GetAsync<OrganizationResponse>($"organizations/me");

        public Task<OrganizationResponse> GetOrganizationAsync(string organizationId) =>
            GetAsync<OrganizationResponse>($"organizations/{organizationId}");

        public Task<ListResponse<OrganizationResponse>> GetOrganizationsListAsync(string from = null, int? limit = null) =>
            GetListAsync<ListResponse<OrganizationResponse>>("organizations", from, limit, null);

        public Task<OrganizationResponse> GetOrganizationAsync(UrlObjectLink<OrganizationResponse> url) =>
            GetAsync(url);
    }
}