﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetAll;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractById;
using Postex.Product.Application.Features.Contratcs.ContractInfos.Queries.GetContractByUser;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractInfoController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public ContractInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllContractInfoQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetContractByIdQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetByUser(Guid userId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetContractByUserQuery { UserId = userId, CityId = cityId, ProvinceId = provinceId }));
        }
    }
}
