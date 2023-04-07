using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Notification.Application.Features.Messages.Commands.SendSms;
using Postex.SharedKernel.Api;

namespace Postex.Notification.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class MessageController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ApiResult> SendSms(SendSmsCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }
}
