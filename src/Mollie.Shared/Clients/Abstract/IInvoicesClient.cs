using System.Threading.Tasks;
using Mollie.Models.Invoice;
using Mollie.Models.List;

using Mollie.Models.Url;

namespace Mollie.Client.Abstract
{
    public interface IInvoicesClient
    {
        Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, bool includeLines = false, bool includeSettlements = false);
        Task<InvoiceResponse> GetInvoiceAsync(UrlObjectLink<InvoiceResponse> url);
        Task<ListResponse<InvoiceResponse>> GetInvoiceListAsync(string reference = null, int? year = null, string from = null, int? limit = null, bool includeLines = false, bool includeSettlements = false);
    }
}