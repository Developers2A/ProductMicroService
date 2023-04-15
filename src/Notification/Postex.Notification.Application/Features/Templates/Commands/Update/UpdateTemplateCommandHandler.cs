using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Commands.Update;

public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, TemplateDto>
{
    private readonly IWriteRepository<Template> _writeRepository;
    private readonly IReadRepository<Template> _readRepository;
    private readonly IMapper _mapper;

    public UpdateTemplateCommandHandler(IWriteRepository<Template> writeRepository, IReadRepository<Template> readRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _mapper = mapper;
    }

    async Task<TemplateDto> IRequestHandler<UpdateTemplateCommand, TemplateDto>.Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template? template = await _readRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (template == null)
            throw new AppException("اطلاعات مورد نظر یافت نشد");

        template.Name = request.Name;
        template.Content = request.Content;
        template.TemplateType = request.TemplateType;
        template.IsCustom = request.IsCustom;

        if (request.Parameters != null && request.Parameters.Any())
        {
            template.Parameters = request.Parameters.Select(x => new TemplateParameter()
            {
                Key = x.Key,
            }).ToList();
        }
        else
        {
            template.Parameters = new List<TemplateParameter>();
        }
        await _writeRepository.UpdateAsync(template, cancellationToken);
        await _writeRepository.SaveChangeAsync(cancellationToken);
        return new TemplateDto()
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
    }
}
