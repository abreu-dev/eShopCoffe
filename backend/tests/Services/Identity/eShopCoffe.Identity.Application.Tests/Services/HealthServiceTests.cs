using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Application.Services;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class HealthServiceTests
    {
        private readonly IBaseContext _baseContext;
        private readonly HealthService _healthService;

        public HealthServiceTests()
        {
            _baseContext = Substitute.For<IBaseContext>();
            _healthService = new HealthService(_baseContext);
        }

        [Fact]
        public void IsHealthy_ShouldReturnContextIsAvailable()
        {
            // Arrange
            var isAvailable = true;
            _baseContext.IsAvailable().Returns(isAvailable);

            // Act
            var result = _healthService.IsHealthy();

            // Assert
            result.Should().Be(isAvailable);
        }
    }
}
