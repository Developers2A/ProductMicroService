using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.ContractCollect_Distributes.Command.Create;
using Postex.Product.Application.Features.ContractCollect_Distributes.Command.Update;
using Postex.Product.Application.Features.ContractCollect_Distributes.Queries;

namespace Postex.Product.Api.Controllers
{
   

    [Route("api/[Controller]")]
    [ApiController]
    public class ContractCollect_DistributeController : Controller
    {
        private readonly IMediator _mediator;

        public ContractCollect_DistributeController(IMediator mediator)
        {
            this._mediator = mediator;
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
        public async Task<IActionResult> GetByCustomer(int? customerId ,int? provinceId,int? cityId)
        {
            return Ok(await _mediator.Send(new GetByCustomerContractCollect_DistributeQuery { CustomerId = customerId,ProvinceId =provinceId,CityId=cityId }));
        }
    }
}
