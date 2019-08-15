using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mollie.Models.Invoice;
using Mollie.Models.List;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class InvoicesClient : OauthClientBase, IInvoicesClient
    {
        public InvoicesClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<InvoiceResponse> GetInvoiceAsync(string invoiceId, bool includeLines = false,
            bool includeSettlements = false)
        {
            var includes = BuildIncludeParameter(includeLines, includeSettlements);
            return ClientService.GetAsync<InvoiceResponse>($"invoices/{invoiceId}{includes.ToQueryString()}");
        }

        public Task<InvoiceResponse> GetInvoiceAsync(UrlObjectLink<InvoiceResponse> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<InvoiceResponse>> GetInvoiceListAsync(string reference = null, int? year = null, string from = null, int? limit = null, bool includeLines = false, bool includeSettlements = false)
        {
            var parameters = BuildIncludeParameter(includeLines, includeSettlements);
            parameters.AddValueIfNotNullOrEmpty(nameof(reference), reference);
            parameters.AddValueIfNotNullOrEmpty(nameof(year), Convert.ToString(year));

            return ClientService.GetListAsync<ListResponse<InvoiceResponse>>($"invoices", from, limit, parameters);
        }

        private Dictionary<string, string> BuildIncludeParameter(bool includeLines = false, bool includeSettlements = false)
        {
            var result = new Dictionary<string, string>();

            var includeList = new List<string>();
            if (includeLines)
            {
                includeList.Add("lines");
            }

            if (includeSettlements)
            {
                includeList.Add("settlements");
            }

            if (includeList.Any())
            {
                result.Add("include", string.Join(",", includeList));
            }

            return result;
        }
    }
}