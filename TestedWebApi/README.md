# TestedWebApi

Integration tests with a dotnet core Web Api project. Using REFIT to test the different Api's from the integration test project.

#### Refit interface

```C#
public interface ITestedWebApiDefinition
{
    [Get("/api/beer")]
    Task<List<Beer>> GetAllBeers();

    [Get("/api/beer/{id}")]
    Task<Beer> GetBeerById(int id);

    [Post("/api/beer")]
    Task UpdateBeer([Body]Beer beer);
}
```

#### Test fixture

Create a custom test fixture:

```c#
public class CustomTestFixture : IDisposable
{
    public readonly ITestedWebApiDefinition Api;

    public CustomTestFixture()
    {
        var server = new TestServer(new WebHostBuilder()
            .UseEnvironment(EnvironmentName.Development)
            .ConfigureTestServices((IServiceCollection serviceCollection) =>
            {
                // Use stubbed repository for integration tests
                serviceCollection.AddSingleton<IBeerRepository, TestedWebApi.Stubs.Beers.BeerRepository>();
            })
            .UseStartup<Startup>());

        var client = server.CreateClient();

        Api = RestService.For<ITestedWebApiDefinition>(client);
    }

    public void Dispose()
    {
    }
}
```

#### Integration tests

Add the test fixture to your test class and start testing:

```c#
public class BeerControllerShould : IClassFixture<CustomTestFixture>
{
    private readonly CustomTestFixture _fixture;

    public BeerControllerShould(CustomTestFixture fixture) =>
        _fixture = fixture;

    [Fact]
    public async Task GetAllBeers()
    {
        var response = await _fixture.Api.GetAllBeers();
        response.Should().NotBeNullOrEmpty();
        response.Should().HaveCount(2);
    }
```
