using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Update;
using Postex.ProfileManagement.Application.Features.CustomerCods.Queries;
using Postex.SharedKernel.Api;

namespace Postex.ProfileManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCodController : Controller
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
