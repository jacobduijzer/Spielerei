using FluentAssertions;
using System.Threading.Tasks;
using TestedWebApi.Domain.Beers;
using Xunit;

namespace TestedWebApi.IntegrationTest.api
{
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

        [Fact]
        public async Task GetBeerById()
        {
            var beer = await _fixture.Api.GetBeerById(1);
            beer.Should().NotBeNull();
            beer.Id.Should().Be(1);
        }

        [Fact]
        public async Task UpdateBeer()
        {
            var updatedBeer = new Beer
            {
                Id = 1,
                Name = "Stubbed Beer - Best Beer Ever",
                IsFavorite = true
            };

            await _fixture.Api.UpdateBeer(updatedBeer);

            var beer = await _fixture.Api.GetBeerById(updatedBeer.Id);

            beer.Name.Should().Be(updatedBeer.Name);
            beer.IsFavorite.Should().Be(updatedBeer.IsFavorite);
        }
    }
}