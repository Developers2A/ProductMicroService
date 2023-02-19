using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Queries;
using Postex.SharedKernel.Api;

namespace Postex.ProfileManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInvoiceInfoController : Controller
    {
        private readonly IMediator mediator;
        public CustomerInvoiceInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerInvoiceInfoCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerInvoiceInfoCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("GetById")]
        public async Task<ApiResult<CustomerInvoiceInfoDto>> GetById(int id)
        {
            var result =await mediator.Send( new GetByIdQuery{ Id=id});
            if (result == null)
            {
                return new ApiResult<CustomerInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerInvoiceInfoDto>(true, result, "");
        }
        [HttpGet("GetByCustomerId")]
        public async Task<ApiResult<CustomerInvoiceInfoDto>> GetByCustomerId(Guid customerId)
        {
            var result =await mediator.Send(new GetByCustomerIdQuery { CustomerId = customerId });
            if (result == null)
            {
                return new ApiResult<CustomerInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerInvoiceInfoDto>(true, result, "");
        }
    }
}
