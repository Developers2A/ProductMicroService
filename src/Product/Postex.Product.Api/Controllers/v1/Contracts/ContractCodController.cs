using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractCods.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCods.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomer;
using Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByCustomerAndValuePrice;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractCodController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ContractCodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCodCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCodCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractCodQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCodQuery { CustomerId = customerId, StateId = provinceId, CityId = cityId }));
        }
        [HttpGet("GetByCustomerAndValuePrice")]
        public async Task<IActionResult> GetByCustomerAndValuePrice(double valuePrice, int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerAndValuePriceContractCodQuery { ValuePrice = valuePrice, CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
