using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Products.Application;
using Products.Domain;
using Products.Infrastructure;
using SharedKernel.Repository;
using AutoMapper;
using Products.DTO;

namespace Products.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Debug)
                .AddMediatR(cfg => cfg.AsScoped(), typeof(ProductsQueryHandler).GetTypeInfo().Assembly)
                .AddScoped<IRepository<Product>, FakeProductsRepository>()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ProductDTO)));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseMvc();
        }
    }
}
