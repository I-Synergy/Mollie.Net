using System.Collections.Generic;
using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Extensions;
using Mollie.Models.Chargeback;
using Mollie.Models.List;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class ChargebacksClient : ClientBase, IChargebacksClient {
        public ChargebacksClient(string apiKey) : base(apiKey) {
        }

        public Task<ChargebackResponse> GetChargebackAsync(string paymentId, string chargebackId) =>
            GetAsync<ChargebackResponse>($"payments/{paymentId}/chargebacks/{chargebackId}");

        public Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string paymentId,
            int? offset = null, int? count = null)  =>
                GetListAsync<ListResponse<ChargebackResponse>>($"payments/{paymentId}/chargebacks", offset, count);

        public Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(int? offset = null,
            int? count = null, string oathProfileId = null, bool? oauthTestmode = null) {
            if (oathProfileId != null || oauthTestmode != null) {
                this.ValidateApiKeyIsOauthAccesstoken();
            }

            // Build parameters
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(oathProfileId)) {
                parameters.Add("profileId", oathProfileId);
            }

            if (oauthTestmode.HasValue) {
                parameters.Add("testmode", oauthTestmode.Value.ToString().ToLower());
            }

            return GetListAsync<ListResponse<ChargebackResponse>>($"chargebacks", offset, count, parameters);
        }
    }
}