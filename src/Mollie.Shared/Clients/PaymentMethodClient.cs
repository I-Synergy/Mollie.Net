using System.Threading.Tasks;
using Mollie.Abstract;
using Mollie.Models.List;
using Mollie.Models.Payment;
using Mollie.Models.PaymentMethod;
using Mollie.Clients.Base;
using Mollie.Enumerations;

namespace Mollie.Client {
    public class PaymentMethodClient : ClientBase, IPaymentMethodClient {
        public PaymentMethodClient(string apiKey) : base(apiKey) {
        }

        public Task<ListResponse<PaymentMethodResponse>> GetPaymentMethodListAsync(int? offset = null,
            int? count = null) =>
            GetListAsync<ListResponse<PaymentMethodResponse>>("methods", offset, count);

        public Task<PaymentMethodResponse> GetPaymentMethodAsync(PaymentMethods paymentMethod) =>
            GetAsync<PaymentMethodResponse>($"methods/{paymentMethod.ToString().ToLower()}");
    }
}