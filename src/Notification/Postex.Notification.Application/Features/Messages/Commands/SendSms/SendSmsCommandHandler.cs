using Kavenegar.Core.Models;
using MediatR;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Application.Features.Templates.Queries.GetAll;
using Postex.Notification.Application.Services;
using Postex.Notification.Domain.Messages;
using Postex.SharedKernel.Exceptions;
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
        SendResult sendResult = new();
        var template = await GetTemplate(request);
        if (template == null)
        {
            if (string.IsNullOrEmpty(request.Message))
            {
                throw new AppException("لطفا متن پیام را وارد نمایید");
            }
            sendResult = await _smsSender.SendSms(new List<string>() { request.Mobile }, request.Message!);
        }
        else
        {
            if (!template!.IsCustom)
            {
                sendResult = await _smsSender.SendSms(new List<string>() { request.Mobile }, template.Name, request.Parameters);
            }
            else
            {
                //TODO : make custom message with template and parameters
                // messages = 
                //sendResult = await _smsSender.SendSms(new List<string>() { request.Mobile }, request.Message!);
            }
        }

        await CreateMessage(sendResult);
        return Unit.Value;
    }

    private async Task CreateMessage(SendResult sendResult)
    {
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
    }

    private async Task<TemplateDto?> GetTemplate(SendSmsCommand request)
    {
        if (!string.IsNullOrEmpty(request.TemplateName))
        {
            var template = await _mediator.Send(new GetTemplatesQuery()
            {
                Name = request.TemplateName
            });

            if (template != null || template!.Any())
            {
                return template!.FirstOrDefault();
            }
        }
        return null;
    }
}
