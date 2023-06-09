﻿using Postex.Notification.Application.Contracts;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Features.Templates.Commands.Update;

public class UpdateTemplateCommand : ITransactionRequest<Template>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Content { get; set; }
    public TemplateType TemplateType { get; set; }
    public List<TemplateParameterDto> Parameters { get; set; }
}
