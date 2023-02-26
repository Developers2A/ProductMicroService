using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetAll;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetByCustomer;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetById;

namespace Postex.Product.Api.Controllers
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

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdContractLeasingCommand { Id = id }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int customerId)
        {
            return Ok(await mediator.Send(new GetByCustomerContractLeasingCommand { CustomerId = customerId }));
        }
    }
}
