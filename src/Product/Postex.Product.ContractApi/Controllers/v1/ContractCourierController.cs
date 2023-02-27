using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomer;
using Postex.Product.Application.Features.Contratcs.ContractCouriers.Queries.GetByCustomerAndCourier;

namespace Postex.Product.ContractApi.Controllers.v1
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
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCourierQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
        [HttpGet("GetByCustomerAndCourier")]
        public async Task<IActionResult> GetByCustomerAndCourier(int courierId, int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerAndCourierContractCourierQuery { CourierId = courierId, CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
