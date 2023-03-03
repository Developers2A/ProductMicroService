using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Notification.Application.Dtos.Templates;
using Postex.Notification.Application.Features.Templates.Commands.Create;
using Postex.Notification.Application.Features.Templates.Commands.Update;
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
        public async Task<IActionResult> Create(CreateTemplateCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateTemplateCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<TemplateDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<TemplateDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<TemplateDto>(true, result, "");
        }
    }
}
