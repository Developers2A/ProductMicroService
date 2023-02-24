using FluentValidation;

namespace Postex.Product.Application.Features.Users.Queries;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(p => p.UserId)
            .NotNull().NotEmpty().WithMessage(" شناسه کاربر الزامی میباشد");
    }
}
