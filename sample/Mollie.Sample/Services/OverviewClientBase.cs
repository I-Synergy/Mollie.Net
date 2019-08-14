using System.Threading.Tasks;
using AutoMapper;
using Mollie.Models;
using Mollie.Models.List;
using Mollie.Models.Url;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services {
    public abstract class OverviewClientBase<T> where T : IResponseObject {
        private readonly IMapper _mapper;

        protected OverviewClientBase(IMapper mapper) {
            this._mapper = mapper;
        }

        protected OverviewModel<T> Map(ListResponse<T> list) {
            return this._mapper.Map<OverviewModel<T>>(list);
        }

        protected UrlObjectLink<ListResponse<T>> CreateUrlObject(string url) {
            return new UrlObjectLink<ListResponse<T>> {
                Href = url
            };
        }
    }
}