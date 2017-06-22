using Mollie.Net.Clients.Base;
using Mollie.Net.Enumerations;
using Mollie.Net.Interfaces;
using Mollie.Net.Models.List;
using Mollie.Net.Models.Payment.Method;
using System.Threading.Tasks;

namespace Mollie.Net.Clients
{
    public class PaymentMethodClient : ClientBase, IPaymentMethodClient
    {
        public PaymentMethodClient(string apiKey) : base(apiKey) { }

        public async Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(int? offset = null, int? count = null)
        {
            return await this.GetListAsync<ListResponse<PaymentMethodResponse>>("methods", offset, count).ConfigureAwait(false);
        }

        public async Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            return await this.GetAsync<PaymentMethodResponse>($"methods/{paymentMethod.ToString().ToLower()}").ConfigureAwait(false);
        }
    }
}
