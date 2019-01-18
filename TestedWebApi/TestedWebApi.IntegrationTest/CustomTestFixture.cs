using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using TestedWebApi.Api;
using TestedWebApi.Domain.Beers;
using TestedWebApi.Stubs.Beers;

namespace TestedWebApi.IntegrationTest
{
    public class CustomTestFixture : IDisposable
    {
        public readonly ITestedWebApiDefinition Api;

        public CustomTestFixture()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment(EnvironmentName.Development)
                .ConfigureTestServices((IServiceCollection serviceCollection) =>
                {
                    serviceCollection.AddSingleton<IBeerRepository, BeerRepository>();
                })
                .UseStartup<Startup>());

            var client = server.CreateClient();

            Api = RestService.For<ITestedWebApiDefinition>(client);
        }

        public void Dispose()
        {
        }
    }
}