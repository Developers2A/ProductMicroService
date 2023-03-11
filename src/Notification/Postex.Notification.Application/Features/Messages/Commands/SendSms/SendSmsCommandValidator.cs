using FluentValidation;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms;

public class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
{
    public SendSmsCommandValidator()
    {
        RuleFor(p => p.Template).
            NotEmpty().NotNull().WithMessage("الگو الزامی می باشد");
        RuleFor(p => p.Mobile).
            NotEmpty().NotNull().WithMessage("شماره موبایل الزامی می باشد");
        RuleFor(p => p.Code)
           .NotEmpty().NotNull().WithMessage("کد معتبر نمی باشد");
    }
}
