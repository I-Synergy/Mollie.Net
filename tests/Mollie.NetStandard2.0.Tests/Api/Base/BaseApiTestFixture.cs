using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mollie.Client;
using Mollie.Models;
using Mollie.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Mollie.Tests.Api
{
    public class BaseApiTestFixture : IDisposable
    {
        public readonly string DefaultRedirectUrl = "https://www.i-synergy.nl";
        public readonly string DefaultWebhookUrl = "https://www.i-synergy.nl/webhook";

        public IServiceProvider ServiceProvider { get; }
        public IConfiguration Configuration { get; }
        public IClientService ClientService { get; } 

        public readonly IPaymentClient PaymentClient;
        public readonly IPaymentMethodClient PaymentMethodClient;
        public readonly IRefundClient RefundClient;
        public readonly ISubscriptionClient SubscriptionClient;
        public readonly IMandateClient MandateClient;
        public readonly ICustomerClient CustomerClient;
        public readonly IProfileClient ProfileClient;
        public readonly IOrderClient OrderClient;

        public BaseApiTestFixture()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            var appSettings = new AppSettings();
            Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);

            services.AddHttpClient();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IJsonConverterService, JsonConverterService>();
            services.AddSingleton<IValidatorService, ValidatorService>();

            // Register all available forms
            services.AddTransient<PaymentClient>();
            services.AddTransient<PaymentMethodClient>();
            services.AddTransient<RefundClient>();
            services.AddTransient<SubscriptionClient>();
            services.AddTransient<MandateClient>();
            services.AddTransient<CustomerClient>();
            services.AddTransient<CustomerClient>();
            services.AddTransient<ProfileClient>();
            services.AddTransient<OrderClient>();

            ServiceProvider = services.BuildServiceProvider();

            ClientService = ServiceProvider.GetRequiredService<IClientService>();
            PaymentClient = ServiceProvider.GetRequiredService<PaymentClient>();
            PaymentMethodClient = ServiceProvider.GetRequiredService<PaymentMethodClient>();
            RefundClient = ServiceProvider.GetRequiredService<RefundClient>();
            SubscriptionClient = ServiceProvider.GetRequiredService<SubscriptionClient>();
            MandateClient = ServiceProvider.GetRequiredService<MandateClient>();
            CustomerClient = ServiceProvider.GetRequiredService<CustomerClient>();
            CustomerClient = ServiceProvider.GetRequiredService<CustomerClient>();
            ProfileClient = ServiceProvider.GetRequiredService<ProfileClient>();
            OrderClient = ServiceProvider.GetRequiredService<OrderClient>();

            EnsureTestApiKey();
        }

        public void Dispose()
        {
        }

        private void EnsureTestApiKey()
        {
            if (string.IsNullOrEmpty(ClientService.ApiKey))
            {
                throw new ArgumentException("Please enter you API key in the BaseMollieApiTestClass class");
            }

            if (!ClientService.ApiKey.StartsWith("test"))
            {
                throw new ArgumentException("You should not run these tests on your live key!");
            }
        }
    }
}
