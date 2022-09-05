using eShopCoffe.Core.Validators;
using FluentValidation.Results;

namespace eShopCoffe.Core.Messaging.Requests
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

        protected abstract CommandValidator<TCommandValidator> GetValidator();
    }
}
