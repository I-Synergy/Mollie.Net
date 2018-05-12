using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.Profile.Request;
using Mollie.Models.Profile.Response;
using Mollie.Clients.Base;
using Mollie.Enumerations;

namespace Mollie.Client {
    public class ProfileClient : ClientBase, IProfileClient {
        public ProfileClient(string apiKey) : base(apiKey) {
        }

        public Task<ProfileResponse> CreateProfileAsync(ProfileRequest request) =>
            PostAsync<ProfileResponse>("profiles", request);

        public Task<ProfileResponse> GetProfileAsync(string profileId) =>
            GetAsync<ProfileResponse>($"profiles/{profileId}");

        public Task<ListResponse<ProfileResponse>> GetProfileListAsync(int? offset = null, int? count = null) =>
            GetListAsync<ListResponse<ProfileResponse>>("profiles", offset, count);

        public Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request) =>
            PostAsync<ProfileResponse>($"profiles/{profileId}", request);

        public Task DeleteProfileAsync(string profileId) =>
            DeleteAsync($"profiles/{profileId}");

        public Task<ListResponseSimple<ApiKey>> GetProfileApiKeyListAsync(string profileId) =>
            GetListAsync<ListResponseSimple<ApiKey>>($"profiles/{profileId}/apikeys", null, null);

        public Task<ApiKey> GetProfileApiKeyAsync(string profileId, Mode mode) =>
            GetAsync<ApiKey>($"profiles/{profileId}/apikeys/{mode.ToString().ToLower()}");

        public Task<ApiKey> ResetProfileApiKeyAsync(string profileId, Mode mode) =>
            PostAsync<ApiKey>($"profiles/{profileId}/apikeys/{mode.ToString().ToLower()}", null);
    }
}