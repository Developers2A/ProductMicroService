using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractItems.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractItems.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractItems.Queries.GetByCustomer;

namespace Postex.Product.Api.Controllers
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
        public async Task<IActionResult> Create(CreateContractContractValueAddedCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractValueAddedCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await mediator.Send(new GetByContractIdContractValueAddedQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await mediator.Send(new GetByCustomerContractValueAddedQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
