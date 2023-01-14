using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractBoxTypes.Command.Create;
using Postex.Contract.Application.Features.ContractBoxTypes.Command.Update;
using Postex.Contract.Application.Features.ContractBoxTypes.Queries;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractBoxTypeController : Controller
    {
        private readonly IMediator _mediator;

        public ContractBoxTypeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractBoxTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractBoxTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractBoxTypeQuery { ContractInfoId = contractInfoId }));
        }
    }
}
