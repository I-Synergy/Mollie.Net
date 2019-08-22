using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mollie.Common;
using Mollie.Models;
using Mollie.Sample.Framework.Extensions;
using Mollie.Sample.Services.Customer;
using Mollie.Sample.Services.Mandate;
using Mollie.Sample.Services.Payment;
using Mollie.Sample.Services.Payment.Refund;
using Mollie.Sample.Services.PaymentMethod;
using Mollie.Sample.Services.Subscription;

namespace Mollie.Sample
{
    public class Startup
    {
        protected IConfiguration Configuration { get; }
        protected IHostingEnvironment Environment { get; }

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Argument.IsNotNull(nameof(environment), environment);
            Argument.IsNotNull(nameof(configuration), configuration);

            Environment = environment;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            var appSettings = new AppSettings();
            Configuration.GetSection(nameof(AppSettings)).Bind(appSettings);

            services.AddMollieApi(appSettings.ApiToken);

            services.AddScoped<IPaymentOverviewClient, PaymentOverviewClient>();
            services.AddScoped<ICustomerOverviewClient, CustomerOverviewClient>();
            services.AddScoped<ISubscriptionOverviewClient, SubscriptionOverviewClient>();
            services.AddScoped<IMandateOverviewClient, MandateOverviewClient>();
            services.AddScoped<IPaymentMethodOverviewClient, PaymentMethodOverviewClient>();
            services.AddScoped<IPaymentStorageClient, PaymentStorageClient>();
            services.AddScoped<ICustomerStorageClient, CustomerStorageClient>();
            services.AddScoped<ISubscriptionStorageClient, SubscriptionStorageClient>();
            services.AddScoped<IMandateStorageClient, MandateStorageClient>();
            services.AddScoped<IRefundPaymentClient, RefundPaymentClient>();

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
