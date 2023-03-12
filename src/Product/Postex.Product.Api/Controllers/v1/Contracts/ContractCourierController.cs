using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomer;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomerAndCourier;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractCourierController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ContractCourierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCourierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCourierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractCourierQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCourierQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
        [HttpGet("GetByCustomerAndCourier")]
        public async Task<IActionResult> GetByCustomerAndCourier(int courierServiceId, int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerAndCourierContractCourierQuery { CourierServiceId = courierServiceId, CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
