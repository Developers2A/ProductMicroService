using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Create;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Update;
using Postex.ProfileManagement.Application.Features.Customers.Queries;

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
        [HttpGet("byid")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send( new GetByIdQuery{ Id=id}));
        }
        [HttpGet("userId")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            return Ok(await mediator.Send(new GetByUserIdQuery { UserId = userId }));
        }
    }
}
