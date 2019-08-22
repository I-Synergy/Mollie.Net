using System.Threading.Tasks;
using Mollie.Client;
using Mollie.Enumerations;
using Mollie.Models.Mandate;

namespace Mollie.Sample.Services.Mandate
{
    public interface IMandateStorageClient {
        Task<MandateResponse> Create(string customerId);
    }

    public class MandateStorageClient : IMandateStorageClient {
        private readonly IMandateClient _mandateClient;
        public MandateStorageClient(IMandateClient mandateClient) {
            _mandateClient = mandateClient;
        }

        public async Task<MandateResponse> Create(string customerId) {
            MandateRequest mandateRequest = CreateDefaultMandateRequest();
            return await _mandateClient.CreateMandateAsync(customerId, mandateRequest);
        }

        private MandateRequest CreateDefaultMandateRequest() {
            return new MandateRequest() {
                Method = PaymentMethods.DirectDebit,
                ConsumerName = "John Smit",
                ConsumerAccount = "NL86INGB0002445588", // IBAN van de belastingdienst ;D
            };
        }
    }
}