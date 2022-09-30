﻿using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Validators.UserValidators;

namespace eShopCoffe.Identity.Domain.Tests.Validators.UserValidators
{
    public class AddUserCommandValidatorTests
    {
        private static readonly string ValidUsername = "Username";
        private static readonly string ValidEmail = "Email";
        private static readonly string ValidPassword = "Password";

        private readonly AddUserCommandValidator _validator;

        public AddUserCommandValidatorTests()
        {
            _validator = new AddUserCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new AddUserCommand(ValidUsername, ValidEmail, ValidPassword);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyUsername()
        {
            // Arrange
            var command = new AddUserCommand(string.Empty, ValidEmail, ValidPassword);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Username)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyPassword()
        {
            // Arrange
            var command = new AddUserCommand(ValidUsername, ValidEmail, string.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
