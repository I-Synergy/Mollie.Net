﻿using Mollie.Net.Clients.Base;
using Mollie.Net.Enumerations;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Profile.Request;
using Mollie.Net.Models.Profile.Response;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class ProfileClient : ClientBase, IProfileClient
    {
        public ProfileClient(string apiKey) : base(apiKey) { }

        public async Task<ProfileResponse> CreateProfileAsync(ProfileRequest request)
        {
            return await this.PostAsync<ProfileResponse>("profiles", request).ConfigureAwait(false);
        }

        public async Task<ProfileResponse> GetProfileAsync(string profileId)
        {
            return await this.GetAsync<ProfileResponse>($"profiles/{profileId}").ConfigureAwait(false);
        }

        public async Task<ListResponse<ProfileResponse>> GetProfileListAsync(int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<ProfileResponse>>("profiles", offset, count).ConfigureAwait(false);
        }

        public async Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request)
        {
            return await this.PostAsync<ProfileResponse>($"profiles/{profileId}", request).ConfigureAwait(false);
        }

        public async Task DeleteProfileAsync(string profileId)
        {
            await this.DeleteAsync($"profiles/{profileId}");
        }

        public async Task<ListResponseSimple<ApiKey>> GetProfileApiKeyListAsync(string profileId)
        {
            return await this.GetListAsync<ListResponseSimple<ApiKey>>($"profiles/{profileId}/apikeys", null, null).ConfigureAwait(false);
        }

        public async Task<ApiKey> GetProfileApiKeyAsync(string profileId, Mode mode)
        {
            return await this.GetAsync<ApiKey>($"profiles/{profileId}/apikeys/{mode.ToString().ToLower()}").ConfigureAwait(false);
        }

        public async Task<ApiKey> ResetProfileApiKeyAsync(string profileId, Mode mode)
        {
            return await this.PostAsync<ApiKey>($"profiles/{profileId}/apikeys/{mode.ToString().ToLower()}", null).ConfigureAwait(false);
        }
    }
}
