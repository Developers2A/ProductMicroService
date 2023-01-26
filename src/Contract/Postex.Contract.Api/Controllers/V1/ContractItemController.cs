using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractItems.Commands.CreateContractItem;
using Postex.Contract.Application.Features.ContractItems.Commands.UpdateContractItem;
using Postex.Contract.Application.Features.ContractItems.Queries;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractItemController : Controller
    {
        private readonly IMediator mediator;

        public ContractItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractItemCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractItemCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await mediator.Send(new GetByContractIdContractItemQuery { ContractInfoId = contractInfoId }));
        }
        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByCustomerContractItemQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
