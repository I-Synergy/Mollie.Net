using Mollie.Net.Models.List;
using Mollie.Net.Models.Mandate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface IMandateClient
    {
        Task<MandateResponse> GetMandateAsync(string customerId, string mandateId);
        Task<ListResponse<MandateResponse>> GetMandateListAsync(string customerId, int? offset = default(int?), int? count = default(int?));
        Task<MandateResponse> CreateMandateAsync(string customerId, MandateRequest request);
    }
}
