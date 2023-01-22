using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractLeasings.Command.Create;
using Postex.Contract.Application.Features.ContractLeasings.Commands.Update;
using Postex.Contract.Application.Features.ContractLeasings.Queries.GetAll;
using Postex.Contract.Application.Features.ContractLeasings.Queries.GetByCustomer;
using Postex.Contract.Application.Features.ContractLeasings.Queries.GetById;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractLeasingController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContractLeasingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractLeasingCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractLeasingCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllContractLeasingCommand()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdContractLeasingCommand { Id = id }));
        }
        [HttpGet("Customer")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            return Ok(await mediator.Send(new GetByCustomerContractLeasingCommand { CustomerId = customerId }));
        }
    }
}
