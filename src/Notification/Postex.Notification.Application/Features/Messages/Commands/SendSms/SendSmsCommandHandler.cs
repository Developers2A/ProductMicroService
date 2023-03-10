using AutoMapper;
using MediatR;
using Postex.Notification.Application.Services;
using Postex.Notification.Domain.Messages;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Messages.Commands.SendSms
{
    public class SendSmsCommandHandler : IRequestHandler<SendSmsCommand>
    {
        private readonly IWriteRepository<Message> _writeRepository;
        private readonly IMapper _mapper;
        private readonly ISmsSender _smsSender;

        public SendSmsCommandHandler(IWriteRepository<Message> writeRepository, IMapper mapper, ISmsSender smsSender)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
            _smsSender = smsSender;
        }

        public async Task<Unit> Handle(SendSmsCommand request, CancellationToken cancellationToken)
        {
            var sendResult = await _smsSender.SendSms(new Dictionary<string, string>(), new List<string>() { request.Mobile }, request.Template);
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
    }
}
