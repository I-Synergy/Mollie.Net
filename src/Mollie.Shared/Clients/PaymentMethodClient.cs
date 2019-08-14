using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mollie.Client.Abstract;
using Mollie.Enumerations;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.PaymentMethod;
using Mollie.Models.Url;

namespace Mollie.Client
{
    public class PaymentMethodClient : ClientBase, IPaymentMethodClient
    {
        public PaymentMethodClient(string apiKey, HttpClient httpClient = null) : base(apiKey, httpClient)
        {
        }

        public async Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethods paymentMethod, bool? includeIssuers = null, string locale = null, bool? includePricing = null, string profileId = null, bool? testmode = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddValueIfNotNullOrEmpty("locale", locale);
            AddOauthParameters(parameters, profileId, testmode);
            BuildIncludeParameter(parameters, includeIssuers, includePricing);

            return await GetAsync<PaymentMethodResponse>($"methods/{paymentMethod.ToString().ToLower()}{parameters.ToQueryString()}").ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentMethodResponse>> GetAllPaymentMethodListAsync(string locale = null, bool? includeIssuers = null, bool? includePricing = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.AddValueIfNotNullOrEmpty("locale", locale);
            BuildIncludeParameter(parameters, includeIssuers, includePricing);

            return await GetListAsync<ListResponse<PaymentMethodResponse>>("methods/all", null, null, parameters).ConfigureAwait(false);
        }

        public async Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(SequenceType? sequenceType = null, string locale = null, Amount amount = null, bool? includeIssuers = null, bool? includePricing = null, string profileId = null, bool? testmode = null, Resource? resource = null)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>() {
                {"sequenceType", sequenceType.ToString().ToLower()},
                {"locale", locale},
                {"amount[value]", amount?.Value},
                {"amount[currency]", amount?.Currency},
                {"resource", resource.ToString().ToLower()}
            };

            AddOauthParameters(parameters, profileId, testmode);
            BuildIncludeParameter(parameters, includeIssuers, includePricing);

            return await GetListAsync<ListResponse<PaymentMethodResponse>>("methods", null, null, parameters).ConfigureAwait(false);
        }

        public async Task<PaymentMethodResponse> GetPaymentMethodAsync(UrlObjectLink<PaymentMethodResponse> url)
        {
            return await GetAsync(url).ConfigureAwait(false);
        }

        private void AddOauthParameters(Dictionary<string, string> parameters, string profileId = null, bool? testmode = null)
        {
            if (!string.IsNullOrWhiteSpace(profileId) || testmode.HasValue)
            {
                ValidateApiKeyIsOauthAccesstoken();

                parameters.AddValueIfNotNullOrEmpty("profileId", profileId);
                if (testmode.HasValue)
                {
                    parameters.AddValueIfNotNullOrEmpty("testmode", testmode.Value.ToString().ToLower());
                }
            }
        }

        private void BuildIncludeParameter(Dictionary<string, string> parameters, bool? includeIssuers = null, bool? includePricing = null)
        {
            var includeList = new List<string>();

            if (includeIssuers == true)
            {
                includeList.Add("issuers");
            }

            if (includePricing == true)
            {
                includeList.Add("pricing");
            }

            if (includeList.Any())
            {
                parameters.Add("include", string.Join(",", includeList));
            }
        }
    }
}