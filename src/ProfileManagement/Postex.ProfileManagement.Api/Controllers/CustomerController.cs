using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Create;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Update;
using Postex.ProfileManagement.Application.Features.Customers.Queries;
using Postex.SharedKernel.Api;

namespace Postex.ProfileManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
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
            var result =await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<CustomerDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerDto>(true, result, "");
        }
        [HttpGet("GetByUserId")]
        public async Task<ApiResult<CustomerDto>> GetByUserId(int userId)
        {
            var result = await mediator.Send(new GetByUserIdQuery { UserId = userId });
            if(result == null)
            {
                return new ApiResult<CustomerDto>(true,null , "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerDto>(true,result,"");
          
        }
    }
}
