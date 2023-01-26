using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractLeasingWarranties.Command.Create;
using Postex.Contract.Application.Features.ContractLeasingWarranties.Commands.Update;
using Postex.Contract.Application.Features.ContractLeasingWarranties.Queries.GetById;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractLeasingWarrantyController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContractLeasingWarrantyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractLeasingWarrantyCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractLeasingWarrantyCommand command)
        {
            return Ok(await mediator.Send(command));
        }
       
        [HttpGet("GetByContractLeasingId")]
        public async Task<IActionResult> GetByContractLeasingId(int contractLeasingId)
        {
            return Ok(await mediator.Send(new GetByContractLeasingIdCommand { ContractLeasingId = contractLeasingId }));
        }
    }
}
