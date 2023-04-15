using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Queries.GetById;

public class GetTemplateByIdQueryHandler : IRequestHandler<GetTemplateByIdQuery, TemplateDto>
{
    private readonly IReadRepository<Template> _readRepository;
    private readonly IMapper _mapper;

    public GetTemplateByIdQueryHandler(IReadRepository<Template> readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<TemplateDto> Handle(GetTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var template = await _readRepository.TableNoTracking.Include(x => x.Parameters)
            .FirstOrDefaultAsync(c => c.Id == request.Id);

        var templateDto = new TemplateDto()
        {
            Id = template!.Id,
            Name = template.Name,
            Content = template.Content,
            TemplateType = template.TemplateType,
            IsCustom = template.IsCustom,
            Parameters = template.Parameters != null ? template.Parameters.Select(x => new TemplateParameterDto()
            {
                Key = x.Key,
            }).ToList() : new List<TemplateParameterDto>()
        };
        return templateDto;
    }
}

