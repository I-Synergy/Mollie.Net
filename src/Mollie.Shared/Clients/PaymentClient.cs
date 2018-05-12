using System.Collections.Generic;
using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Extensions;
using Mollie.Models.List;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Clients.Base;

namespace Mollie.Client {
    public class PaymentClient : ClientBase, IPaymentClient {

	    public PaymentClient(string apiKey) : base(apiKey) { }

        public Task<PaymentResponse> CreatePaymentAsync(PaymentRequest paymentRequest) {

            if (!string.IsNullOrWhiteSpace(paymentRequest.ProfileId) || paymentRequest.Testmode.HasValue || paymentRequest.ApplicationFee != null) {
                this.ValidateApiKeyIsOauthAccesstoken();
            }

            return PostAsync<PaymentResponse>("payments", paymentRequest);
        }

	    public Task<PaymentResponse> GetPaymentAsync(string paymentId, bool testmode = false) {
	        if (testmode) {
	            this.ValidateApiKeyIsOauthAccesstoken();
            }

		    var testmodeParameter = testmode ? "?testmode=true" : string.Empty;

			return GetAsync<PaymentResponse>($"payments/{paymentId}{testmodeParameter}");
		}

		public Task DeletePaymentAsync(string paymentId) =>
            DeleteAsync($"payments/{paymentId}");

	    public Task<ListResponse<PaymentResponse>> GetPaymentListAsync(int? offset = null, int? count = null, string profileId = null, bool? testMode = null) {
	        if (!string.IsNullOrWhiteSpace(profileId) || testMode.HasValue) {
	            this.ValidateApiKeyIsOauthAccesstoken();
            }

		    var parameters = new Dictionary<string, object>();

	        if (!string.IsNullOrWhiteSpace(profileId)) {
	            parameters.Add("profileId", profileId);
            }

	        if (testMode.HasValue) {
	            parameters.Add("testmode", testMode.Value.ToString().ToLower());
            }

			return GetListAsync<ListResponse<PaymentResponse>>($"payments", offset, count, parameters);
		}
    }
}