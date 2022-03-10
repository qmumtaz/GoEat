using FluentValidation;

namespace GoEat.Application.Order.AddOrderItem;

public class AddOrderItemValidator : AbstractValidator<AddOrderItem>
{
    public AddOrderItemValidator()
    {
        //RuleFor(x => x.OrderId)
        //    .NotEmpty()
        //    .NotNull();

        RuleFor(x => x.OrderItemId)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
            .LessThan(100).WithMessage("Quantity too high, must be less than 100.")
            .NotNull();
    }
}
