using eShopCoffe.Core.Data.Pagination;

namespace eShopCoffe.Core.Tests.Data.Pagination
{
    public class BaseParametersTests
    {
        [Fact]
        public void Page_ShouldSetValue()
        {
            // Arrange
            var expectedValue = 5;
            var parameter = new ConcreteParameters();

            // Act
            parameter.Page = expectedValue;

            // Assert
            parameter.Page.Should().Be(expectedValue);
        }

        [Fact]
        public void Page_WhenValueLessThanZero_ShouldSetToDefault()
        {
            // Arrange
            var parameter = new ConcreteParameters();

            // Act
            parameter.Page = -1;

            // Assert
            parameter.Page.Should().Be(BaseParameters.PageDefault);
        }

        [Fact]
        public void Size_ShouldSetValue()
        {
            // Arrange
            var expectedValue = 5;
            var parameter = new ConcreteParameters();

            // Act
            parameter.Size = expectedValue;

            // Assert
            parameter.Size.Should().Be(expectedValue);
        }

        [Fact]
        public void Size_WhenValueNotInformed_ShouldSetToDefault()
        {
            // Arrange & Act
            var parameter = new ConcreteParameters();

            // Assert
            parameter.Size.Should().Be(BaseParameters.SizeDefault);
        }

        [Fact]
        public void Size_WhenValueLessThanOne_ShouldSetToDefault()
        {
            // Arrange
            var parameter = new ConcreteParameters();

            // Act
            parameter.Size = -1;

            // Assert
            parameter.Size.Should().Be(BaseParameters.SizeDefault);
        }

        [Fact]
        public void Size_WhenValueGreatherThanMaxSize_ShouldSetToMaxSize()
        {
            // Arrange
            var parameter = new ConcreteParameters();

            // Act
            parameter.Size = BaseParameters.MaxSize + 1;

            // Assert
            parameter.Size.Should().Be(BaseParameters.MaxSize);
        }

        internal sealed class ConcreteParameters : BaseParameters
        {
        }
    }
}
