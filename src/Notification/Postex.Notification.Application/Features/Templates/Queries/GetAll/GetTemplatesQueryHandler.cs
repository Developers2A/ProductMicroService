using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Queries.GetAll;

public class GetTemplatesQueryHandler : IRequestHandler<GetTemplatesQuery, List<TemplateDto>>
{
    private readonly IReadRepository<Template> readRepository;

    public GetTemplatesQueryHandler(IReadRepository<Template> readRepository)
    {
        this.readRepository = readRepository;
    }

    public async Task<List<TemplateDto>> Handle(GetTemplatesQuery request, CancellationToken cancellationToken)
    {
        var templateQuery = readRepository.TableNoTracking;
        if (request.TemplateType.HasValue && request.TemplateType > 0)
        {
            templateQuery = templateQuery.Where(x => x.TemplateType == (TemplateType)request.TemplateType);
        }

        var templates = await templateQuery.Include(x => x.Parameters).Select
            (c => new TemplateDto
            {
                Id = c.Id,
                Name = c.Name,
                Content = c.Content,
                TemplateType = c.TemplateType,
                Parameters = c.Parameters.Select(x => new TemplateParameterDto()
                {
                    Key = x.Key,
                }).ToList()
            }
            ).ToListAsync(cancellationToken);
        return templates;
    }
}
