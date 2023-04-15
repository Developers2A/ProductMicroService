using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Commands.Create;

public class CreateTemplateCommandHandler : IRequestHandler<CreateTemplateCommand, TemplateDto>
{
    private readonly IWriteRepository<Template> _writeRepository;
    private readonly IReadRepository<Template> _readRepository;

    public CreateTemplateCommandHandler(IWriteRepository<Template> writeRepository, IReadRepository<Template> readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    async Task<TemplateDto> IRequestHandler<CreateTemplateCommand, TemplateDto>.Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {

        var isExists = await _readRepository.TableNoTracking.AnyAsync(x => x.Name == request.Name);
        if (isExists)
        {
            throw new AppException("الگویی با این نام در سیستم وجود دارد");
        }
        var template = new Template()
        {
            Name = request.Name,
            IsCustom = request.IsCustom,
            TemplateType = request.TemplateType,
            Content = request.Content,
        };

        if (request.Parameters != null && request.Parameters.Any())
        {
            template.Parameters = request.Parameters.Select(x => new TemplateParameter()
            {
                Key = x.Key,
            }).ToList();
        }

        await _writeRepository.AddAsync(template, cancellationToken);
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
