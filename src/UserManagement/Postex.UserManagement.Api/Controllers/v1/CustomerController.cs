using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Application.Features.Customers.Commands.Create;
using Postex.UserManagement.Application.Features.Customers.Commands.Update;
using Postex.UserManagement.Application.Features.Customers.Queries.GetById;
using Postex.UserManagement.Application.Features.Customers.Queries.GetByUserId;

namespace Postex.UserManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class CustomerController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<CustomerDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<CustomerDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerDto>(true, result, "");
        }

        [HttpGet("GetByUserId")]
        public async Task<ApiResult<CustomerDto>> GetByUserId(Guid userId)
        {
            var result = await mediator.Send(new GetByUserIdQuery { UserId = userId });
            if (result == null)
            {
                return new ApiResult<CustomerDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerDto>(true, result, "");
        }
    }
}
