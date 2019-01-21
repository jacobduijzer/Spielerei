using FluentAssertions;
using System.Threading.Tasks;
using TestedWebApi.Domain.Bars;
using Xunit;

namespace TestedWebApi.IntegrationTest.api
{
    public class BarControllerShould : IClassFixture<CustomTestFixture>
    {
        private readonly CustomTestFixture _fixture;

        public BarControllerShould(CustomTestFixture fixture) =>
            _fixture = fixture;

        [Fact]
        public async Task GetAllBars()
        {
            var response = await _fixture.Api.GetAllBars();
            response.Should().NotBeNullOrEmpty();
            response.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetBarById()
        {
            var bar = await _fixture.Api.GetBarById(1);
            bar.Should().NotBeNull();
            bar.Id.Should().Be(1);
        }

        [Fact]
        public async Task UpdateBeer()
        {
            var updatedBar = new Bar
            {
                Id = 1,
                Name = "Best Bar Ever",
                City = "BarTown",
                IsFavorite = true
            };

            await _fixture.Api.UpdateBar(updatedBar);

            var bar = await _fixture.Api.GetBarById(updatedBar.Id);

            bar.Name.Should().Be(updatedBar.Name);
            bar.IsFavorite.Should().Be(updatedBar.IsFavorite);
        }
    }
}