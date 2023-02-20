using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.ContractInfos.Queries.GetAll;
using Postex.Product.Application.Features.Contracts.Commands.CreateContractCommand;
using Postex.Product.Application.Features.Contracts.Commands.UpdateContractCommand;
using Postex.Product.Application.Features.Contracts.Queries.GetContractByCustomer;
using Postex.Product.Application.Features.Contracts.Queries.GetContractById;


namespace Postex.Product.Api.Controllers
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
        public async Task<IActionResult> GetByCustomer(Guid customerId,int? provinceId,int? cityId)
        {
            return Ok(await mediator.Send(new GetContractByCustomer{CustomerId=customerId, CityId = cityId,ProvinceId=provinceId }));
        }
    }
}
