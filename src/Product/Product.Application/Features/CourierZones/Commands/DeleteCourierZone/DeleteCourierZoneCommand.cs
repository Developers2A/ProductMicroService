using Product.Application.Contracts;

namespace Product.Application.Features.CourierZones.Commands.DeleteCourierZone
{
    public class DeleteCourierZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
