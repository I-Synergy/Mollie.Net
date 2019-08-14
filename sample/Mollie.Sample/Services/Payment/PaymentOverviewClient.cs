using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client.Abstract;
using Mollie.Models.Payment.Response;
using Mollie.Sample.Models;
using Mollie.Sample.Services;

namespace Mollie.Sample.Services.Payment {
    public class PaymentOverviewClient : OverviewClientBase<PaymentResponse>, IPaymentOverviewClient {
        private readonly IPaymentClient _paymentClient;

        public PaymentOverviewClient(IMapper mapper, IPaymentClient paymentClient) : base(mapper) {
            this._paymentClient = paymentClient;
        }

        public async Task<OverviewModel<PaymentResponse>> GetList() {
            return this.Map(await this._paymentClient.GetPaymentListAsync());
        }

        public async Task<OverviewModel<PaymentResponse>> GetListByUrl(string url) {
            return this.Map(await this._paymentClient.GetPaymentListAsync(this.CreateUrlObject(url)));
        }
    }
}