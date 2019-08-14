using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mollie.Sample.Framework.Middleware;
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
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMollieApi(Configuration["MollieApiKey"]);
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
