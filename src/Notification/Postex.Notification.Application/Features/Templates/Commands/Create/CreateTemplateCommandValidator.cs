using FluentValidation;

namespace Postex.Notification.Application.Features.Templates.Commands.Create;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(p => p.Content).
            NotEmpty().NotNull().WithMessage("محتوای الگو الزامی می باشد");
        RuleFor(p => p.TemplateType).
            NotEmpty().NotNull().WithMessage("نوع الگو الزامی می باشد");
    }
}
