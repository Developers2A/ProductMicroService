using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Notification.Domain.Templates;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Notification.Application.Features.Templates.Commands.Update;

public class UpdateTemplateCommandHandler : IRequestHandler<UpdateTemplateCommand, Template>
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

    async Task<Template> IRequestHandler<UpdateTemplateCommand, Template>.Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        Template template = await _readRepository.TableNoTracking.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (template == null)
            throw new AppException("اطلاعات مورد نظر یافت نشد");

        template.Content = request.Content;
        template.TemplateType = request.TemplateType;
        template.Parameters = request.Parameters.Select(x => new TemplateParameter()
        {
            Key = x.Key,
            Value = x.Value
        }).ToList();
        await _writeRepository.UpdateAsync(template, cancellationToken);
        await _writeRepository.SaveChangeAsync(cancellationToken);
        return template;
    }
}
