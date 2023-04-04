using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUser;
using Postex.Product.Application.Features.Contratcs.ContractValueAddeds.Queries.GetByUserAndValueAdded;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractValueAddedController : BaseApiControllerWithDefaultRoute
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

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByUserContractValueAddedQuery { UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }

        [HttpGet("GetByUserAndValueAdded")]
        public async Task<IActionResult> GetByCustomerAndValueAdded(int ValueAddedId, Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByUserAndValueAddedContractValueAddedQuery { ValueAddedId = ValueAddedId, UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
