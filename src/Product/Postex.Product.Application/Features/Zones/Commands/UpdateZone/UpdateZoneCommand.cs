using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
