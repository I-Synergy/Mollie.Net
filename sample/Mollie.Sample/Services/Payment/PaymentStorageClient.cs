using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Mollie.Client;
using Mollie.Models.Payment.Request;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Payment
{
    public class PaymentStorageClient : IPaymentStorageClient {
        private readonly IPaymentClient _paymentClient;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PaymentStorageClient(IPaymentClient paymentClient, IMapper mapper, IConfiguration configuration) {
            _paymentClient = paymentClient;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task Create(CreatePaymentModel model) {
            PaymentRequest paymentRequest = _mapper.Map<PaymentRequest>(model);
            paymentRequest.RedirectUrl = _configuration["DefaultRedirectUrl"];

            await _paymentClient.CreatePaymentAsync(paymentRequest);
        }
    }
}