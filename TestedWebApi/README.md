# TestedWebApi

Integration tests with a dotnet core Web Api project. Using REFIT to test the different Api's from the integration test project.

```
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
```

```
[Fact]
public async Task GetAllBeers()
{
    var response = await _fixture.Api.GetAllBeers();
    response.Should().NotBeNullOrEmpty();
    response.Should().HaveCount(2);
}
```
