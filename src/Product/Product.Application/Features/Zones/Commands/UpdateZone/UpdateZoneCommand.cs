using Product.Application.Contracts;

namespace Product.Application.Features.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
