using AutoMapper;
using MediatR;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Commands.Create
{
    public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, Template>
    {
        private readonly IWriteRepository<Template> _writeRepository;
        private readonly IMapper _mapper;

        public CreateTemplateCommandHandler(IWriteRepository<Template> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<Template> IRequestHandler<CreateTemplateCommand, Template>.Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Template>(request);
            await _writeRepository.AddAsync(customer, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customer;
        }
    }
}
