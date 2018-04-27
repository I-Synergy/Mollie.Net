using System.Threading.Tasks;
using Mollie.Enumerations;
using Mollie.Models.List;
using Mollie.Models.Profile.Request;
using Mollie.Models.Profile.Response;

namespace Mollie.Abstract {
    public interface IProfileClient {
        Task<ProfileResponse> CreateProfileAsync(ProfileRequest request);
        Task<ProfileResponse> GetProfileAsync(string profileId);
        Task<ListResponse<ProfileResponse>> GetProfileListAsync(int? offset = null, int? count = null);
        Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request);
        Task DeleteProfileAsync(string profileId);
        Task<ListResponseSimple<ApiKey>> GetProfileApiKeyListAsync(string profileId);
        Task<ApiKey> GetProfileApiKeyAsync(string profileId, Mode mode);
        Task<ApiKey> ResetProfileApiKeyAsync(string profileId, Mode mode);
    }
}