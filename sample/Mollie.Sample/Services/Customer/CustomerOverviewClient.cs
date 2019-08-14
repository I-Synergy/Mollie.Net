using System.Threading.Tasks;
using AutoMapper;
using Mollie.Client.Abstract;
using Mollie.Models.Customer;
using Mollie.Sample.Models;
using Mollie.Sample.Services;

namespace Mollie.Sample.Services.Customer {
    public class CustomerOverviewClient : OverviewClientBase<CustomerResponse>, ICustomerOverviewClient {
        private readonly ICustomerClient _customerClient;

        public CustomerOverviewClient(IMapper mapper, ICustomerClient customerClient) : base(mapper) {
            this._customerClient = customerClient;
        }

        public async Task<OverviewModel<CustomerResponse>> GetList() {
            return this.Map(await this._customerClient.GetCustomerListAsync());
        }

        public async Task<OverviewModel<CustomerResponse>> GetListByUrl(string url) {
            return this.Map(await this._customerClient.GetCustomerListAsync(this.CreateUrlObject(url)));
        }
    }
}