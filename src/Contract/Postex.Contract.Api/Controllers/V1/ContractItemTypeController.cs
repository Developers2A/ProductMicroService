﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractItemTypes.Commands.CreateContractItemType;
using Postex.Contract.Application.Features.ContractItemTypes.Commands.UpdateContractItemType;
using Postex.Contract.Application.Features.ContractItemTypes.Queries;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractItemTypeController : Controller
    {
        private readonly IMediator mediator;

        public ContractItemTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractItemTypeCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractItemTypeCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetContractItemTypeQuery { }));
        }
    }
}