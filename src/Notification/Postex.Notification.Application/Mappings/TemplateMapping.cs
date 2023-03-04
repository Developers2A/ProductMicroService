using AutoMapper;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Application.Features.Templates.Commands.Create;
using Postex.Notification.Application.Features.Templates.Commands.Update;
using Postex.Notification.Domain.Templates;

namespace Postex.Notification.Application.Mappings
{
    public class TemplateMapping : Profile
    {
        public TemplateMapping()
        {
            CreateMap<CreateTemplateCommand, Template>();
            CreateMap<UpdateTemplateCommand, Template>();
            CreateMap<Template, TemplateDto>();
        }
    }
}
