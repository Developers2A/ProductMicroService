using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Update;
using Postex.ProfileManagement.Application.Features.CustomerCods.Queries;

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
        [HttpGet("GetById")]        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdQuery { Id = id }));
        }
        [HttpGet("GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            return Ok(await mediator.Send(new GetByCustomerIdQuery { CustomerId = customerId }));
        }

    }
}
