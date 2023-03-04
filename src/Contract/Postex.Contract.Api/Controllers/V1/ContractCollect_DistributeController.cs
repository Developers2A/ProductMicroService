using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractCollect_Distributes.Commands.Create;
using Postex.Contract.Application.Features.ContractCollect_Distributes.Commands.Update;
using Postex.Contract.Application.Features.ContractCollect_Distributes.Queries.GetByContractId;
using Postex.Contract.Application.Features.ContractCollect_Distributes.Queries.GetByCustomer;

namespace Postex.Contract.Api.Controllers.V1
{


    [Route("api/[Controller]")]
    [ApiController]
    public class ContractCollect_DistributeController : Controller
    {
        private readonly IMediator _mediator;

        public ContractCollect_DistributeController(IMediator mediator)
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

        [HttpGet("GetByCustomer")]
        public async Task<IActionResult> GetByCustomer(Guid? customerId, int? provinceId, int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCollect_DistributeQuery { CustomerId = customerId, ProvinceId = provinceId, CityId = cityId }));
        }
    }
}
