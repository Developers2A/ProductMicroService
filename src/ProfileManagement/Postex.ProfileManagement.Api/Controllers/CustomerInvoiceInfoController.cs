using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Queries;

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
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send( new GetByIdQuery{ Id=id}));
        }
        [HttpGet("GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            return Ok(await mediator.Send(new GetByCustomerIdQuery { CustomerId = customerId }));
        }
    }
}
