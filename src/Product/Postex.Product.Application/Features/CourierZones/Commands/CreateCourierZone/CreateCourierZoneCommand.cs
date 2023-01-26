using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZones.Commands.CreateCourierZone
{
    public class CreateCourierZoneCommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
