using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Mandate;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Mandate
{
    public class MandateOverviewClient : OverviewClientBase<MandateResponse>, IMandateOverviewClient {
        private readonly IMandateClient _mandateClient;

        public MandateOverviewClient(IMapper mapper, IMandateClient mandateClient) : base (mapper) {
            _mandateClient = mandateClient;
        }

        public async Task<OverviewModel<MandateResponse>> GetList(string customerId) {
            return Map(await _mandateClient.GetMandateListAsync(customerId));
        }

        public async Task<OverviewModel<MandateResponse>> GetListByUrl(string url) {
            return Map(await _mandateClient.GetMandateListAsync(CreateUrlObject(url)));
        }
    }
}