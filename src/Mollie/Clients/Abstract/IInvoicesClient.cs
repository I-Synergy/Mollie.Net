using System.Threading.Tasks;
using Mollie.Models.Invoice;
using Mollie.Models.List;

namespace Mollie.Abstract {
    public interface IInvoicesClient {
        Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, bool includeLines = false, bool includeSettlements = false);
        Task<ListResponse<InvoiceResponse>> GetInvoiceListAsync(string reference = null, int? year = null, int? offset = null, int? count = null, bool includeLines = false, bool includeSettlements = false);
    }
}