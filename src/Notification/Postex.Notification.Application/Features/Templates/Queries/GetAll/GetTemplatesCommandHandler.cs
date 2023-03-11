using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Queries.GetAll;

public class GetTemplatesCommandHandler : IRequestHandler<GetTemplatesCommand, List<TemplateDto>>
{
    private readonly IReadRepository<Template> readRepository;

    public GetTemplatesCommandHandler(IReadRepository<Template> readRepository)
    {
        this.readRepository = readRepository;
    }
    public async Task<List<TemplateDto>> Handle(GetTemplatesCommand request, CancellationToken cancellationToken)
    {
        var items = await readRepository.TableNoTracking.Include(x => x.Parameters).Select
            (c => new TemplateDto
            {
                Id = c.Id,
                Content = c.Content,
                TemplateType = c.TemplateType,
                Parameters = c.Parameters.Select(x => new TemplateParameterDto()
                {
                    Key = x.Key,
                    Value = x.Value
                }).ToList()
            }
            ).ToListAsync(cancellationToken);
        return items;
    }
}
