using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractBoxPrices.Commands.Create;
using Postex.Contract.Application.Features.ContractBoxPrices.Commands.Update;
using Postex.Contract.Application.Features.ContractBoxPrices.Queries.GetByContractId;
using Postex.Contract.Application.Features.ContractBoxPrices.Queries.GetByCustomer;

namespace Postex.Contract.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractBoxPriceController : Controller
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
        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(Guid? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractBoxPriceQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
