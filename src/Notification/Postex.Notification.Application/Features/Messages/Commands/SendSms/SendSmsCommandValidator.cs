using FluentValidation;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms;

public class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
{
    public SendSmsCommandValidator()
    {
        RuleFor(p => p.Message).NotEmpty().NotNull().When(x => x.TemplateId == 0 || x.TemplateId == null)
            .WithMessage("متن پیام و یا شناسه الگو را وارد نمایید");
        RuleFor(p => p.Mobile).
            NotEmpty().NotNull().WithMessage("شماره موبایل الزامی می باشد");
    }
}
