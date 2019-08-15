using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Profile.Request;
using Mollie.Models.Profile.Response;

namespace Mollie.Client
{
    public class ProfileClient : ClientBase, IProfileClient
    {
        public ProfileClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<ProfileResponse> CreateProfileAsync(ProfileRequest request) =>
            PostAsync<ProfileResponse>("profiles", request);

        public Task<ProfileResponse> GetProfileAsync(string profileId) =>
            GetAsync<ProfileResponse>($"profiles/{profileId}");

        public Task<ListResponse<ProfileResponse>> GetProfileListAsync(string from = null, int? limit = null) =>
            GetListAsync<ListResponse<ProfileResponse>>("profiles", from, limit);

        public Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request) =>
            PostAsync<ProfileResponse>($"profiles/{profileId}", request);

        public Task DeleteProfileAsync(string profileId) =>
            DeleteAsync($"profiles/{profileId}");
    }
}