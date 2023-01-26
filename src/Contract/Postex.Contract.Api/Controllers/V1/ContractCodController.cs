using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractCods.Command.Create;
using Postex.Contract.Application.Features.ContractCods.Command.Update;
using Postex.Contract.Application.Features.ContractCods.Queries;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractCodController : Controller
    {
        private readonly IMediator _mediator;

        public ContractCodController(IMediator mediator)
        {
            this._mediator = mediator;
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
            return Ok(await _mediator.Send(new GetByCustomerContractCodQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
