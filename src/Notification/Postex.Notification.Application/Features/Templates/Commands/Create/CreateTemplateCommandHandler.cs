using AutoMapper;
using MediatR;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Commands.Create;

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
        var template = _mapper.Map<Template>(request);
        template.Parameters = request.Parameters.Select(x => new TemplateParameter()
        {
            Key = x.Key,
        }).ToList();
        await _writeRepository.AddAsync(template, cancellationToken);
        await _writeRepository.SaveChangeAsync(cancellationToken);
        return template;
    }
}
