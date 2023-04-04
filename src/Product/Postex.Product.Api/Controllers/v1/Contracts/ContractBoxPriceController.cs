using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUser;
using Postex.Product.Application.Features.Contratcs.ContractBoxPrices.Queries.GetByUserAndBoxType;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractBoxPriceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ContractBoxPriceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractBoxPriceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractBoxPriceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractBoxPriceQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserContractBoxPriceQuery { UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }

        [HttpGet("GetByUserAndBoxType")]
        public async Task<IActionResult> GetByUserAndBoxType(int boxTypeId, Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserAndBoxTypeContractBoxPriceQuery { BoxTypeId = boxTypeId, UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
