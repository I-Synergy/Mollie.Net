using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Models.Url;
using Mollie.Services;

namespace Mollie.Client
{
    public class PaymentClient : ClientBase, IPaymentClient
    {

        public PaymentClient(IClientService clientService) : base(clientService)
        {
        }

        public Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest)
        {
            if (!string.IsNullOrWhiteSpace(paymentRequest.ProfileId) || paymentRequest.Testmode.HasValue || paymentRequest.ApplicationFee != null)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            return ClientService.PostAsync<PaymentResponse>("payments", paymentRequest);
        }

        public Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false)
        {
            if (testmode)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            var testmodeParameter = testmode ? "?testmode=true" : string.Empty;

            return ClientService.GetAsync<PaymentResponse>($"payments/{paymentId}{testmodeParameter}");
        }

        public Task DeletePaymentAsync(string paymentId) =>
            ClientService.DeleteAsync($"payments/{paymentId}");

        public Task<PaymentResponse> GetPaymentAsync(UrlObjectLink<PaymentResponse> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<PaymentResponse>> GetPaymentListAsync(UrlObjectLink<ListResponse<PaymentResponse>> url) =>
            ClientService.GetAsync(url);

        public Task<ListResponse<PaymentResponse>> GetPaymentListAsync(string from = null, int? limit = null, string profileId = null, bool? testMode = null)
        {
            if (!string.IsNullOrWhiteSpace(profileId) || testMode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();
            }

            var parameters = new Dictionary<string, string>();
            parameters.AddValueIfNotNullOrEmpty(nameof(profileId), profileId);
            parameters.AddValueIfNotNullOrEmpty(nameof(testMode), Convert.ToString(testMode).ToLower());

            return ClientService.GetListAsync<ListResponse<PaymentResponse>>($"payments", from, limit, parameters);
        }
    }
}