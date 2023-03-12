using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Commands.CreateList;
using Postex.Product.Application.Features.Contratcs.ContractAccountingTemplates.Queries.GetContractById;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractAccountingTemplateController : BaseApiControllerWithDefaultRoute
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
