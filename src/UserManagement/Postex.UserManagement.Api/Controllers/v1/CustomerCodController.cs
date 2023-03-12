using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Application.Features.CustomerCods.Commands.Create;
using Postex.UserManagement.Application.Features.CustomerCods.Commands.Update;
using Postex.UserManagement.Application.Features.CustomerCods.Queries.GetByCustomerId;
using Postex.UserManagement.Application.Features.CustomerCods.Queries.GetById;

namespace Postex.UserManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class CustomerCodController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public CustomerCodController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCodCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCodCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetById")]
        public async Task<ApiResult<CustomerCodDto>> GetById(int id)
        {
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<CustomerCodDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerCodDto>(true, result, "");
        }

        [HttpGet("GetByCustomerId")]
        public async Task<ApiResult<CustomerCodDto>> GetByCustomerId(int customerId)
        {
            var result = await mediator.Send(new GetByCustomerIdQuery { CustomerId = customerId });
            if (result == null)
            {
                return new ApiResult<CustomerCodDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerCodDto>(true, result, "");
        }
    }
}
