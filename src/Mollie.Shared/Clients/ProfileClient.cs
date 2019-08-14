using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
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

        public async Task<ProfileResponse> CreateProfileAsync(ProfileRequest request)
        {
            return await PostAsync<ProfileResponse>("profiles", request).ConfigureAwait(false);
        }

        public async Task<ProfileResponse> GetProfileAsync(string profileId)
        {
            return await GetAsync<ProfileResponse>($"profiles/{profileId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<ProfileResponse>> GetProfileListAsync(string from = null, int? limit = null)
        {
            return await GetListAsync<ListResponse<ProfileResponse>>("profiles", from, limit).ConfigureAwait(false);
        }

        public async Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request)
        {
            return await PostAsync<ProfileResponse>($"profiles/{profileId}", request).ConfigureAwait(false);
        }

        public async Task DeleteProfileAsync(string profileId)
        {
            await DeleteAsync($"profiles/{profileId}").ConfigureAwait(false);
        }
    }
}