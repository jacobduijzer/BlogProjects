using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;
using SharedKernel.Events;
using Website.Application.Customers;
using Website.Application.Products;
using Website.Infrastructure;
using Website.Infrastructure.Products;

namespace Website.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var productsEndpoint = Configuration.GetSection("ProductsApi")["EndPoint"];

            services
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
                .AddScoped<IEventDispatcher, EventDispatcher>()
                .AddScoped<IEventHandler<CustomerLoggedInEvent>, CustomerLoggedInHandler>()
                .AddScoped<IProductsService, ProductsService>()
                .AddScoped<ICachedProductsDecorator, CachedProductsService>()
                .AddMediatR(cfg => cfg.AsScoped(), typeof(PopulateCacheWorker).GetTypeInfo().Assembly)
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ProductsQueryHandler).GetTypeInfo().Assembly)
                .AddHostedService<PopulateCacheWorker>()
                .AddMemoryCache()                
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRefitClient<IProductsApi>(new RefitSettings())
                .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{productsEndpoint}"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
