using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Application.Features.Templates.Commands.Create;
using Postex.Notification.Application.Features.Templates.Commands.Update;
using Postex.Notification.Application.Features.Templates.Queries.GetAll;
using Postex.Notification.Application.Features.Templates.Queries.GetById;
using Postex.SharedKernel.Api;

namespace Postex.Notification.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class TemplateController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public TemplateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResult<TemplateDto>> Create(CreateTemplateCommand command)
        {
            var template = await mediator.Send(command);
            return new ApiResult<TemplateDto>(true, template, "");
        }

        [HttpPut]
        public async Task<ApiResult<TemplateDto>> Put(UpdateTemplateCommand command)
        {
            var template = await mediator.Send(command);
            return new ApiResult<TemplateDto>(true, template, "");
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<TemplateDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetTemplateByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<TemplateDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<TemplateDto>(true, result, "");
        }

        [HttpGet]
        public async Task<ApiResult<List<TemplateDto>>> Get()
        {
            var result = await mediator.Send(new GetTemplatesQuery());
            return new ApiResult<List<TemplateDto>>(true, result, "");
        }
    }
}
