using eShopCoffe.Core.Validators;

namespace eShopCoffe.Core.Tests.Validators
{
    public class ResultTests
    {
        [Fact]
        public void Success_ShouldInstantiateResult()
        {
            // Arrange & Act
            var result = Result.Success();

            // Assert
            result.HasSucceed.Should().BeTrue();
            result.ErrorCode.Should().BeNull();
            result.ErrorMessage.Should().BeNull();
        }

        [Fact]
        public void Success_ShouldInstantiateResult_WhenTyped()
        {
            // Arrange & Act
            var item = new ResultItem();
            var result = Result<ResultItem>.Success(item);

            // Assert
            result.HasSucceed.Should().BeTrue();
            result.ErrorCode.Should().BeNull();
            result.ErrorMessage.Should().BeNull();
            result.Item.Should().Be(item);
        }

        [Fact]
        public void Failure_ShouldInstantiateResult()
        {
            // Arrange & Act
            var errorCode = "ErrorCode";
            var errorMessage = "ErrorMessage";
            var result = Result.Failure(errorCode, errorMessage);

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be(errorCode);
            result.ErrorMessage.Should().Be(errorMessage);
        }

        [Fact]
        public void Failure_ShouldInstantiateResult_WhenTyped()
        {
            // Arrange & Act
            var errorCode = "ErrorCode";
            var errorMessage = "ErrorMessage";
            var result = Result<ResultItem>.Failure(errorCode, errorMessage);

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be(errorCode);
            result.ErrorMessage.Should().Be(errorMessage);
            result.Item.Should().BeNull();
        }

        internal sealed class ResultItem
        {
        }
    }
}
