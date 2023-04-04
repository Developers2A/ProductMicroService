using FluentValidation;

namespace Postex.UserManagement.Application.Features.UserCods.Commands.Create
{
    public class CreateUserCodCommandValidator : AbstractValidator<CreateUserCodCommand>
    {
        public CreateUserCodCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
