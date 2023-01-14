using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractCouriers.Command.Create;
using Postex.Contract.Application.Features.ContractCouriers.Command.Update;
using Postex.Contract.Application.Features.ContractCouriers.Queries;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractCourierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractCourierController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCourierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCourierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractCourierQuery { ContractInfoId = contractInfoId }));
        }
    }
}
