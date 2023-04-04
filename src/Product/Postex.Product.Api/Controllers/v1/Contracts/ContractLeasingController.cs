using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Create;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Commands.Update;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetAll;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetById;
using Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetByUser;
using Postex.SharedKernel.Api;

namespace Postex.Product.Api.Controllers.v1.Contracts
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class ContractLeasingController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator mediator;

        public ContractLeasingController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractLeasingCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContractLeasingCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllContractLeasingCommand()));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdContractLeasingCommand { Id = id }));
        }

        [HttpGet("GetByUser")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            return Ok(await mediator.Send(new GetByUserContractLeasingCommand { UserId = userId }));
        }
    }
}
