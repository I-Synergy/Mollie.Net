using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client;
using Mollie.Models.Customer;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Customer
{
    public class CustomerStorageClient : ICustomerStorageClient {
        private readonly ICustomerClient _customerClient;
        private readonly IMapper _mapper;

        public CustomerStorageClient(ICustomerClient customerClient, IMapper mapper) {
            _customerClient = customerClient;
            _mapper = mapper;
        }

        public async Task Create(CreateCustomerModel model) {
            CustomerRequest customerRequest = _mapper.Map<CustomerRequest>(model);
            await _customerClient.CreateCustomerAsync(customerRequest);
        }
    }
}