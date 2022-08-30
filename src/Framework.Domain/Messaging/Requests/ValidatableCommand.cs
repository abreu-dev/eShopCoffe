using FluentValidation.Results;
using Framework.Core.Validators;

namespace Framework.Core.Messaging.Requests
{
    public abstract class ValidatableCommand<TCommandValidator> : Command
        where TCommandValidator : ValidatableCommand<TCommandValidator>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected ValidatableCommand()
        {
            ValidationResult = new ValidationResult();
        }

        public bool IsValid()
        {
            ValidationResult = GetValidator().Validate((TCommandValidator)this);
            return ValidationResult.IsValid;
        }

        public abstract CommandValidator<TCommandValidator> GetValidator();
    }
}
