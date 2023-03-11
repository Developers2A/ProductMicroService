using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Queries.GetById;

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, TemplateDto>
{
    private readonly IReadRepository<Template> _readRepository;
    private readonly IMapper _mapper;

    public GetByIdQueryHandler(IReadRepository<Template> readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<TemplateDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        var template = await _readRepository.Table
            .Where(c => c.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        var templateDto = _mapper.Map<TemplateDto>(template);
        return templateDto;
    }
}

