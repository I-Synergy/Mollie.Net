using Microsoft.Extensions.DependencyInjection;
using Mollie.Client;
using Mollie.Services;

namespace Mollie
{
    public static class MollieApiClientServiceExtensions
    {
        public static IServiceCollection AddMollieApi(this IServiceCollection services, string apiKey)
        {
            services.AddHttpClient();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IJsonConverterService, JsonConverterService>();
            services.AddSingleton<IValidatorService, ValidatorService>();

            services.AddScoped<IChargebacksClient, ChargebacksClient>();
            services.AddScoped<IConnectClient, ConnectClient>();
            services.AddScoped<ICustomerClient, CustomerClient>();
            services.AddScoped<IInvoicesClient, InvoicesClient>();
            services.AddScoped<IMandateClient, MandateClient>();
            services.AddScoped<IOrderClient, OrderClient>();
            services.AddScoped<IOrganizationsClient, OrganizationsClient>();
            services.AddScoped<IPaymentClient, PaymentClient>();
            services.AddScoped<IPaymentMethodClient, PaymentMethodClient>();
            services.AddScoped<IPermissionsClient, PermissionsClient>();
            services.AddScoped<IProfileClient, ProfileClient>();
            services.AddScoped<IRefundClient, RefundClient>();
            services.AddScoped<ISettlementsClient, SettlementsClient>();
            services.AddScoped<ISubscriptionClient, SubscriptionClient>();

            return services;
        }
    }
}
