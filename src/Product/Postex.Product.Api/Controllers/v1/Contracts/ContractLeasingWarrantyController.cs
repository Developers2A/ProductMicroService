﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractLeasingWarranties.Queries.GetByContractLeasingId;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractLeasingWarrantyController : BaseApiControllerWithDefaultRoute
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
