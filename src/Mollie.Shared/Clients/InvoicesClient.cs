using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Extensions;
using Mollie.Models.Invoice;
using Mollie.Models.List;
using Mollie.Client.Base;

namespace Mollie.Client {
    public class InvoicesClient : OAuthClientBase, IInvoicesClient {
        public InvoicesClient(string oauthAccessToken) : base(oauthAccessToken) {
        }

        public Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, bool includeLines = false,
            bool includeSettlements = false) {
            var includes = this.BuildIncludeParameter(includeLines, includeSettlements);

            return GetAsync<InvoiceResponse>($"invoices/{invoiceId}{includes.ToQueryString()}");
        }

        public Task<ListResponse<InvoiceResponse>> GetInvoiceListAsync(string reference = null, int? year = null, int? offset = null, int? count = null, bool includeLines = false, bool includeSettlements = false) {
            // Build parameter list
            var parameters = this.BuildIncludeParameter(includeLines, includeSettlements);

            if (!string.IsNullOrWhiteSpace(reference)) {
                parameters.Add("reference", reference);
            }

            if (year.HasValue) {
                parameters.Add("year", year.Value.ToString());
            }

            return GetListAsync<ListResponse<InvoiceResponse>>($"invoices", offset, count, parameters);
        }

        private Dictionary<string, object> BuildIncludeParameter(bool includeLines = false,
            bool includeSettlements = false) {
            var result = new Dictionary<string, object>();

            var includeList = new List<string>();
            if (includeLines) {
                includeList.Add("lines");
            }

            if (includeSettlements) {
                includeList.Add("settlements");
            }

            if (includeList.Any()) {
                result.Add("include", string.Join(",", includeList));
            }

            return result;
        }
    }
}