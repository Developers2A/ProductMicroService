﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomer;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByCustomerAndValueAdded;

namespace Postex.Product.ContractApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractValueAddedController : Controller
    {
        private readonly IMediator mediator;

        public ContractValueAddedController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractContractValueAddedCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractValueAddedCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await mediator.Send(new GetByContractIdContractValueAddedQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByCustomerContractValueAddedQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
        [HttpGet("GetByCustomerAndValueAdded")]
        public async Task<IActionResult> GetByCustomerAndValueAdded(int ValueAddedId, int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByCustomerAndValueAddedContractValueAddedQuery { ValueAddedId = ValueAddedId, CustomerId = customerId, StateId = provinceId, CityId = cityId }));
        }
    }
}
