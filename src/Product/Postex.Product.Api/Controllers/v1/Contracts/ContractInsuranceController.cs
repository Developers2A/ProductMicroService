using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUser;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByUserAndValuePrice;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractInsuranceController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ContractInsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractInsuranceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractInsuranceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractInsuranceQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserContractInsuranceQuery { UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }

        [HttpGet("GetByUserAndValuePrice")]
        public async Task<IActionResult> GetByUserAndValuePrice(double valuePrice, Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserAndValuePriceContractInsuranceQuery { ValuePrice = valuePrice, UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
