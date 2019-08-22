using System.Globalization;
using AutoMapper;
using Mollie.Models;
using Mollie.Models.Customer;
using Mollie.Models.List;
using Mollie.Models.Mandate;
using Mollie.Models.Payment.Request;
using Mollie.Models.Payment.Response;
using Mollie.Models.PaymentMethod;
using Mollie.Models.Subscription;
using Mollie.Sample.Models;

namespace Mollie.Sample.Services.Automapper {
    public class MollieApiProfile : Profile {
        public MollieApiProfile() {
            CreateMap<CreatePaymentModel, PaymentRequest>()
                .ForMember(x => x.Amount, m => m.MapFrom(x => new Amount(x.Currency, x.Amount.ToString(CultureInfo.InvariantCulture))));

            CreateMap<CreateSubscriptionModel, SubscriptionRequest>()
                .ForMember(x => x.Amount, m => m.MapFrom(x => new Amount(x.Currency, x.Amount.ToString(CultureInfo.InvariantCulture))))
                .ForMember(x => x.Interval, m => m.MapFrom(x => $"{x.IntervalAmount} {x.IntervalPeriod.ToString().ToLower()}"));

            CreateMap<CreateCustomerModel, CustomerRequest>();

            CreateOverviewMap<PaymentResponse>();
            CreateOverviewMap<CustomerResponse>();
            CreateOverviewMap<SubscriptionResponse>();
            CreateOverviewMap<MandateResponse>();
            CreateOverviewMap<PaymentMethodResponse>();
        }

        private void CreateOverviewMap<TResponseType>() where TResponseType : IResponseObject {
            CreateMap<ListResponse<TResponseType>, OverviewModel<TResponseType>>()
                .ForMember(x => x.Items, m => m.MapFrom(x => x.Items))
                .ForMember(x => x.Navigation, m => m.MapFrom(x => new OverviewNavigationLinksModel(x.Links.Previous, x.Links.Next)));
        }
    }
}