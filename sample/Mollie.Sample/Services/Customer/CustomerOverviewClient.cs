using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Customer;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Customer
{
    public class CustomerOverviewClient : OverviewClientBase<CustomerResponse>, ICustomerOverviewClient {
        private readonly ICustomerClient _customerClient;

        public CustomerOverviewClient(IMapper mapper, ICustomerClient customerClient) : base(mapper) {
            _customerClient = customerClient;
        }

        public async Task<OverviewModel<CustomerResponse>> GetList() {
            return Map(await _customerClient.GetCustomerListAsync());
        }

        public async Task<OverviewModel<CustomerResponse>> GetListByUrl(string url) {
            return Map(await _customerClient.GetCustomerListAsync(CreateUrlObject(url)));
        }
    }
}