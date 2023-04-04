using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByUser;
using Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByUserAndBoxType;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractCollectDistributeController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public ContractCollectDistributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCollect_DistributeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCollect_DistributeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractCollect_DistributeQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserContractCollect_DistributeQuery { UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }

        [HttpGet("GetByUserAndBoxType")]
        public async Task<IActionResult> GetByUserBoxTypeCourierService(int courierServiceId, int boxTypeId, Guid? userId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByUserAndBoxTypeContractCollect_DistributeQuery { CourierServiceId = courierServiceId, BoxTypeId = boxTypeId, UserId = userId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
