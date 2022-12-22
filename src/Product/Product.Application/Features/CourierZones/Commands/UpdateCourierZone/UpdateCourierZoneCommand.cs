using Product.Application.Contracts;

namespace Product.Application.Features.CourierZones.Commands.UpdateCourierZone
{
    public class UpdateCourierZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int CourierId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
