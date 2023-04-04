using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Create;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Update;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetById;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Queries.GetByUserId;

namespace Postex.UserManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class UserInvoiceInfoController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public UserInvoiceInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInvoiceInfoCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserInvoiceInfoCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<UserInvoiceInfoDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<UserInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<UserInvoiceInfoDto>(true, result, "");
        }

        [HttpGet("GetByUserId")]
        public async Task<ApiResult<UserInvoiceInfoDto>> GetByUserId(Guid userId)
        {
            var result = await mediator.Send(new GetByUserIdQuery { UserId = userId });
            if (result == null)
            {
                return new ApiResult<UserInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<UserInvoiceInfoDto>(true, result, "");
        }
    }
}
