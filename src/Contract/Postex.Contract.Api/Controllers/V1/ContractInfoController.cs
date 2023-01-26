using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractInfos.Queries.GetAll;
using Postex.Contract.Application.Features.Contracts.Commands.CreateContractCommand;
using Postex.Contract.Application.Features.Contracts.Commands.UpdateContractCommand;
using Postex.Contract.Application.Features.Contracts.Queries.GetContractByCustomer;
using Postex.Contract.Application.Features.Contracts.Queries.GetContractById;


namespace Postex.Contract.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ContractInfoController : Controller
    {
        private readonly IMediator mediator;

        public ContractInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllContractInfoCommand() ));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetContractById { Id = id }));
        }
        [HttpGet]
        public async Task<IActionResult> GetByCustomer(int customerId,int? provinceId,int? cityId)
        {
            return Ok(await mediator.Send(new GetContractByCustomer{CustomerId=customerId, CityId = cityId,ProvinceId=provinceId }));
        }
    }
}
