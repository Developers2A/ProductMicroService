using FluentValidation;

namespace Postex.Product.Application.Features.Customers.Queries;

public class GetCustomerByUserIdQueryValidator : AbstractValidator<GetCustomerByUserIdQuery>
{
    public GetCustomerByUserIdQueryValidator()
    {
        RuleFor(p => p.UserId)
            .NotNull().NotEmpty().WithMessage(" شناسه کاربر الزامی میباشد");
    }
}
