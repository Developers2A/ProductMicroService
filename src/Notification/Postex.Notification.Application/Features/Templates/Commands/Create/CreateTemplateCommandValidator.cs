using FluentValidation;

namespace Postex.Notification.Application.Features.Templates.Commands.Create;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(p => p.FirstName).
            NotEmpty().NotNull().WithMessage("نام الزامی می باشد");
        RuleFor(p => p.FirstName).
            NotEmpty().NotNull().WithMessage("نام خانوادگی الزامی می باشد");
        RuleFor(p => p.Email)
           .EmailAddress().WithMessage("فرمت آدرس ایمیل معتبر نمی باشد");
    }
}
