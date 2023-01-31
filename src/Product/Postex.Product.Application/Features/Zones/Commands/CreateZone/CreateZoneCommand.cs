using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Zones.Commands.CreateZone
{
    public class CreateZoneCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
