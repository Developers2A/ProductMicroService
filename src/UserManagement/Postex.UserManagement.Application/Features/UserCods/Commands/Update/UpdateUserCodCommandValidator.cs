using FluentValidation;

namespace Postex.UserManagement.Application.Features.UserCods.Commands.Update
{
    public class UpdateUserCodCommandValidator : AbstractValidator<UpdateUserCodCommand>
    {
        public UpdateUserCodCommandValidator()
        {
            //RuleFor(p=> p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
            //RuleFor(p => p.FirstName).
            //    NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        }
    }
}
