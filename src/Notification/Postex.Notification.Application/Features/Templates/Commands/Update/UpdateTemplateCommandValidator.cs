using FluentValidation;

namespace Postex.Notification.Application.Features.Templates.Commands.Update
{
    public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
    {
        public UpdateTemplateCommandValidator()
        {
            RuleFor(p => p.TemplateContent).
                NotEmpty().NotNull().WithMessage("متن الگو الزامی می باشد");
        }
    }
}
