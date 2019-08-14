using System.Threading.Tasks;
using Mollie.Models.List;

using Mollie.Models.Mandate;
using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface IMandateClient
    {
        Task<MandateResponse> GetMandateAsync(string customerId, string mandateId);
        Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, string from = null, int? limit = null);
        Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request);
        Task<ListResponse<MandateResponse>> GetMandateListAsync(UrlObjectLink<ListResponse<MandateResponse>> url);
        Task<MandateResponse> GetMandateAsync(UrlObjectLink<MandateResponse> url);
        Task RevokeMandate(string customerId, string mandateId);
    }
}