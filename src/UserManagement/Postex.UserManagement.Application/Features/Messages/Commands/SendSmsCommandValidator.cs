using FluentValidation;

namespace Postex.UserManagement.Application.Features.Messages.Commands;

public class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
{
    public SendSmsCommandValidator()
    {
        RuleFor(p => p.Mobile)
            .NotNull().NotEmpty().WithMessage(" شناسه کاربر الزامی میباشد");
    }
}
