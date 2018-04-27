using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.Organization;
using Mollie.Client.Base;

namespace Mollie.Client {
    public class OrganizationsClient : OAuthClientBase, IOrganizationsClient {
        public OrganizationsClient(string oauthAccessToken) : base(oauthAccessToken) {
        }

        public Task<OrganizationResponse> GetOrganizationAsync(string organizationId) =>
            GetAsync<OrganizationResponse>($"organizations/{organizationId}");
    }
}