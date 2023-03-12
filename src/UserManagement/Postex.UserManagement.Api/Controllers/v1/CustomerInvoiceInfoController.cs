using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Create;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Queries.GetByCustomerId;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Queries.GetById;

namespace Postex.UserManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    public class CustomerInvoiceInfoController : BaseApiControllerWithDefaultRoute
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
            var result = await mediator.Send(new GetByIdQuery { Id = id });
            if (result == null)
            {
                return new ApiResult<CustomerInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerInvoiceInfoDto>(true, result, "");
        }

        [HttpGet("GetByCustomerId")]
        public async Task<ApiResult<CustomerInvoiceInfoDto>> GetByCustomerId(int customerId)
        {
            var result = await mediator.Send(new GetByCustomerIdQuery { CustomerId = customerId });
            if (result == null)
            {
                return new ApiResult<CustomerInvoiceInfoDto>(true, null, "اطلاعاتی پیدا نشد");
            }
            return new ApiResult<CustomerInvoiceInfoDto>(true, result, "");
        }
    }
}
