using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create;
using Postex.Contract.Application.Features.ContractAccountingTemplates.Queries.GetContractById;

namespace Postex.Contract.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractAccountingTemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractAccountingTemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractAccountingTemplateCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("List")]
        public async Task<IActionResult> Create(CreateContractAccountingTemplatesCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractAccountingTemplate { ContractInfoId = contractInfoId }));
        }
    }
}
