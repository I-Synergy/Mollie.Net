using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class PaymentClient : ClientBase, IPaymentClient
    {

        public PaymentClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient) { }

        public async Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            if (!string.IsNullOrWhiteSpace(paymentRequest.ProfileId) || paymentRequest.Testmode.HasValue || paymentRequest.ApplicationFee != null)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            return await PostAsync<PaymentResponse>("payments", paymentRequest).ConfigureAwait(false);
        }

        public async Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false)
        {
            if (testmode)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            var testmodeParameter = testmode ? "?testmode=true" : string.Empty;

            return await GetAsync<PaymentResponse>($"payments/{paymentId}{testmodeParameter}").ConfigureAwait(false);
        }

        public async Task DeletePaymentAsync(string paymentId)
        {
            await DeleteAsync($"payments/{paymentId}").ConfigureAwait(false);
        }

        public async Task<PaymentResponse> GetPaymentAsync(UrlObjectLink<PaymentResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetPaymentListAsync(UrlObjectLink<ListResponse<PaymentResponse>> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentResponse>> GetPaymentListAsync(string from = null, int? limit = null, string profileId = null, bool? testMode = null)
        {
            if (!string.IsNullOrWhiteSpace(profileId) || testMode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            var parameters = new Dictionary<string, string>();
            parameters.AddValueIfNotNullOrEmpty(nameof(profileId), profileId);
            parameters.AddValueIfNotNullOrEmpty(nameof(testMode), Convert.ToString(testMode).ToLower());

            return await GetListAsync<ListResponse<PaymentResponse>>($"payments", from, limit, parameters).ConfigureAwait(false);
        }
    }
}