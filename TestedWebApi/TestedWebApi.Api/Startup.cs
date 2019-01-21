using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestedWebApi.Application.Bars.UseCases;
using TestedWebApi.Application.Beers;
using TestedWebApi.Domain.Bars;
using TestedWebApi.Domain.Beers;
using TestedWebApi.Domain.Shared;
using TestedWebApi.Infrastructure.Bars;
using TestedWebApi.Infrastructure.Beers;
using TestedWebApi.Infrastructure.Shared;

namespace TestedWebApi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatR(typeof(BarsHandler));

            services.AddScoped<IBeerService, BeerService>();
            services.AddSingleton<IDatabase<Beer>, BeerDatabase>();
            services.AddScoped<IRepository<Beer>, Repository<Beer>>();

            services.AddScoped<IDatabase<Bar>, BarDatabase>();
            services.AddScoped<IRepository<Bar>, Repository<Bar>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}