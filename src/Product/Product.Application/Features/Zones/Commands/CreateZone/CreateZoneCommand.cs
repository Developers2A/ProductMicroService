using Product.Application.Contracts;

namespace Product.Application.Features.Zones.Commands.CreateZone
{
    public class CreateZoneCommand : ITransactionRequest
    {
        public string Name { get; set; }
    }
}
