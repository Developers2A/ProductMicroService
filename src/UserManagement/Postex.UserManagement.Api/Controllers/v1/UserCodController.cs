using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.UserCods.Commands.Create;
using Postex.UserManagement.Application.Features.UserCods.Commands.Update;
using Postex.UserManagement.Application.Features.UserCods.Queries.GetById;
using Postex.UserManagement.Application.Features.UserCods.Queries.GetByUserId;

namespace Postex.UserManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class UserCodController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public UserCodController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCodCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateUserCodCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<UserCodDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<UserCodDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<UserCodDto>(true, result, "");
        }

        [HttpGet("GetByUserIdId")]
        public async Task<ApiResult<UserCodDto>> GetByUserId(Guid userId)
        {
            var result = await mediator.Send(new GetByUserIdQuery { UserId = userId });
            if (result == null)
            {
                return new ApiResult<UserCodDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<UserCodDto>(true, result, "");
        }
    }
}
