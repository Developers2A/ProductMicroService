using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postex.Contract.Application.Features.ContractLeasings.Command.Create;

namespace Postex.Contract.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractLeasingController : ControllerBase
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
    }
}
