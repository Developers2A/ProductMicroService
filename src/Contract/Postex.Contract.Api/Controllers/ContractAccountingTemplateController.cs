using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractAccountingTemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContractAccountingTemplateController(IMediator mediator)
        {
            this._mediator = mediator;
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
    }
}
