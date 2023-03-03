using MediatR;
using Postex.Notification.Application.Dtos.Templates;

namespace Postex.Notification.Application.Features.Templates.Queries.GetById;

public class GetByIdQuery : IRequest<TemplateDto>
{
    public int Id { get; set; }
}
