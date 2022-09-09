using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Core.Tests.Messaging.Requests
{
    public class ValidatableCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange & Act
            var command = new ConcreteCommand();

            // Assert
            command.ValidationResult.Should().NotBeNull();
        }

        [Fact]
        public void IsValid_ShouldGetValidatorAndValidate()
        {
            // Arrange
            var command = new ConcreteCommand();

            // Act
            var isValid = command.IsValid();

            // Assert
            isValid.Should().BeTrue();
        }

        internal sealed class ConcreteCommand : ValidatableCommand<ConcreteCommand>
        {
            protected override CommandValidator<ConcreteCommand> GetValidator()
            {
                return new ConcreteCommandValidator();
            }
        }

        internal sealed class ConcreteCommandValidator : CommandValidator<ConcreteCommand>
        {
        }
    }
}
