using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.PaymentMethod;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.PaymentMethod
{
    public class PaymentMethodOverviewClient : OverviewClientBase<PaymentMethodResponse>, IPaymentMethodOverviewClient {
        private readonly IPaymentMethodClient _paymentMethodClient;

        public PaymentMethodOverviewClient(IMapper mapper, IPaymentMethodClient paymentMethodClient) : base(mapper) {
            _paymentMethodClient = paymentMethodClient;
        }

        public async Task<OverviewModel<PaymentMethodResponse>> GetList() {
            return Map(await _paymentMethodClient.GetPaymentMethodListAsync());
        }
    }
}