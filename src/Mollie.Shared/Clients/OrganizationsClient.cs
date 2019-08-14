using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<OrganizationResponse> GetCurrentOrganizationAsync()
        {
            return await GetAsync<OrganizationResponse>($"organizations/me").ConfigureAwait(false);
        }

        public async Task<OrganizationResponse> GetOrganizationAsync(string organizationId)
        {
            return await GetAsync<OrganizationResponse>($"organizations/{organizationId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<OrganizationResponse>> GetOrganizationsListAsync(string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<OrganizationResponse>>("organizations", from, limit, null).ConfigureAwait(false);
        }

        public async Task<OrganizationResponse> GetOrganizationAsync(UrlObjectLink<OrganizationResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }
    }
}