using Mollie.Net.Models.Issuer;
using Mollie.Net.Models.List;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mollie.Net.Interfaces
{
    public interface IIssuerClient
    {
        Task<IssuerResponse> GetIssuerAsync(string issuerId);
        Task<ListResponse<IssuerResponse>> GetIssuerListAsync(int? offset = default(int?), int? count = default(int?));
    }
}
