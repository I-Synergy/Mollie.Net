using System.Threading.Tasks;
using Mollie.Models.List;

using Mollie.Models.Profile.Request;
using Mollie.Models.Profile.Response;

namespace Mollie.Client
{
    public interface IProfileClient
    {
        Task<ProfileResponse> CreateProfileAsync(ProfileRequest request);
        Task<ProfileResponse> GetProfileAsync(string profileId);
        Task<ListResponse<ProfileResponse>> GetProfileListAsync(string from = null, int? limit = null);
        Task<ProfileResponse> UpdateProfileAsync(string profileId, ProfileRequest request);
        Task DeleteProfileAsync(string profileId);
    }
}