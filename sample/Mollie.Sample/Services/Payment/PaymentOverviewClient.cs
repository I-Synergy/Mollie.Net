using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Payment.Response;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Payment
{
    public class PaymentOverviewClient : OverviewClientBase<PaymentResponse>, IPaymentOverviewClient {
        private readonly IPaymentClient _paymentClient;

        public PaymentOverviewClient(IMapper mapper, IPaymentClient paymentClient) : base(mapper) {
            _paymentClient = paymentClient;
        }

        public async Task<OverviewModel<PaymentResponse>> GetList() {
            return Map(await _paymentClient.GetPaymentListAsync());
        }

        public async Task<OverviewModel<PaymentResponse>> GetListByUrl(string url) {
            return Map(await _paymentClient.GetPaymentListAsync(CreateUrlObject(url)));
        }
    }
}