using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByUser;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByUserAndCourier;
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

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserContractCourierQuery { UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }

        [HttpGet("GetByUserAndCourier")]
        public async Task<IActionResult> GetByUserAndCourier(int courierServiceId, Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserAndCourierContractCourierQuery { CourierServiceId = courierServiceId, UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
