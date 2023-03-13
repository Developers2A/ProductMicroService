using Kavenegar.Core.Models;
using MediatR;
using Postex.Notification.Application.Features.Templates.Queries.GetById;
using Postex.Notification.Application.Services;
using Postex.Notification.Domain.Messages;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms;

public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand>
{
    private readonly IWriteRepository<Message> _writeRepository;
    private readonly ISmsSender _smsSender;
    private IMediator _mediator;

    public SendSmsCommandHandler(IWriteRepository<Message> writeRepository, ISmsSender smsSender, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _smsSender = smsSender;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        var templateName = await GetTemplate(request);
        SendResult sendResult = new();

        if (request.Parameters != null && request.Parameters.Any())
        {
            sendResult = await _smsSender.SendSms(new List<string>() { request.Mobile }, templateName, request.Parameters);
        }
        else
        {
            sendResult = await _smsSender.SendSms(new List<string>() { request.Mobile }, request.Message!);
        }
        await _writeRepository.AddAsync(new Message()
        {
            Sender = sendResult.Sender,
            Receptor = sendResult.Receptor,
            MessageType = MessageType.SMS,
            SendDate = DateTime.Now,
            MessageContent = sendResult.Message,
            Status = sendResult.Status,
            StatusText = sendResult.StatusText
        });

        return Unit.Value;
    }

    private async Task<string> GetTemplate(SendSmsCommand request)
    {
        if (request.TemplateId.HasValue)
        {
            var template = await _mediator.Send(new GetTemplateByIdQuery()
            {
                Id = request.TemplateId.Value
            });

            if (template != null)
            {
                return template.Name;
            }
        }
        return "rahgiry";
    }
}
