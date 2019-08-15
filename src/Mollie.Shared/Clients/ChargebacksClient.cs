using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Models.Chargeback;
using Mollie.Models.List;

namespace Mollie.Client
{
    public class ChargebacksClient : ClientBase, IChargebacksClient
    {
        public ChargebacksClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public Task<ChargebackResponse> GetChargebackAsync(string paymentId, string chargebackId) =>
            GetAsync<ChargebackResponse>($"payments/{paymentId}/chargebacks/{chargebackId}");

        public Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string paymentId, string from = null, int? limit = null) =>
            GetListAsync<ListResponse<ChargebackResponse>>($"payments/{paymentId}/chargebacks", from, limit);

        public Task<ListResponse<ChargebackResponse>> GetChargebacksListAsync(string profileId = null, bool? testmode = null)
        {
            if (profileId != null || testmode != null)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            // Build parameters
            var parameters = new Dictionary<string, string>();
            parameters.AddValueIfNotNullOrEmpty(nameof(profileId), profileId);
            parameters.AddValueIfNotNullOrEmpty(nameof(testmode), Convert.ToString(testmode).ToLower());

            return GetListAsync<ListResponse<ChargebackResponse>>($"chargebacks", null, null, parameters);
        }
    }
}