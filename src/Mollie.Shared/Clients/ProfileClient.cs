using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Profile.Request;
using Mollie.Models.Profile.Response;
using Mollie.Services;

namespace Mollie.Client
{
    public class ProfileClient : ClientBase, IProfileClient
    {
        public ProfileClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<ProfileResponse> CreateProfileAsync(ProfileRequest request) =>
            ClientService.PostAsync<ProfileResponse>("profiles", request);

        public Task<ProfileResponse> GetProfileAsync(string profileId) =>
            ClientService.GetAsync<ProfileResponse>($"profiles/{profileId}");

        public Task<ListResponse<ProfileResponse>> GetProfileListAsync(string from = null, int? limit = null) =>
            ClientService.GetListAsync<ListResponse<ProfileResponse>>("profiles", from, limit);

        public Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request) =>
            ClientService.PostAsync<ProfileResponse>($"profiles/{profileId}", request);

        public Task DeleteProfileAsync(string profileId) =>
            ClientService.DeleteAsync($"profiles/{profileId}");
    }
}