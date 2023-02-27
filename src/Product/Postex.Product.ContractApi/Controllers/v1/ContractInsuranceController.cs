using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByContractId;
using Postex.Product.Application.Features.Contratcs.ContractInsurances.Queries.GetByCustomer;

namespace Postex.Product.ContractApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractInsuranceController : Controller
    {
        private readonly IMediator _mediator;

        public ContractInsuranceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractInsuranceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractInsuranceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetByContarctId")]
        public async Task<IActionResult> GetByContractInfoId(int contractInfoId)
        {
            return Ok(await _mediator.Send(new GetByContractIdContractInsuranceQuery { ContractInfoId = contractInfoId }));
        }

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(int? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractInsuranceQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
