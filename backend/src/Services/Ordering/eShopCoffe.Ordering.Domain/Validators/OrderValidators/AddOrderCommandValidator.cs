using eShopCoffe.Core.Extensions;
using eShopCoffe.Core.Validators;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using eShopCoffe.Ordering.Domain.Enums;
using FluentValidation;

namespace eShopCoffe.Ordering.Domain.Validators.OrderValidators
{
    public class AddOrderCommandValidator : CommandValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(x => x.Cep)
                .NotEmpty();

            RuleFor(x => x.PaymentMethod)
                .NotEmpty()
                .Must(x => BeValidPaymentMethod(x));

            RuleFor(x => x.Items)
                .NotEmpty();

            RuleForEach(x => x.Items).SetValidator(new OrderItemValidator());
        }

        private static bool BeValidPaymentMethod(string paymentMethod)
        {
            return EnumExtensions.IsAnEnumDisplayName<PaymentMethod>(paymentMethod);
        }

        internal class OrderItemValidator : AbstractValidator<AddOrderCommand.OrderItem>
        {
            public OrderItemValidator()
            {
                RuleFor(x => x.ProductId)
                    .NotEmpty();

                RuleFor(x => x.Amount)
                   .GreaterThan(0);
            }
        }
    }
}
