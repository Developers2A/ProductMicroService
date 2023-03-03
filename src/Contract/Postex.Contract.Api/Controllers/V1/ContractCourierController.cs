using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractCouriers.Commands.Create;
using Postex.Contract.Application.Features.ContractCouriers.Commands.Update;
using Postex.Contract.Application.Features.ContractCouriers.Queries.GetByContractId;
using Postex.Contract.Application.Features.ContractCouriers.Queries.GetByCustomer;

namespace Postex.Contract.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractCourierController : ControllerBase
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
        public async Task<IActionResult> GetByCustomer(Guid? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCourierQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
