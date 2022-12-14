using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZones.Commands.DeleteCourierServiceZone
{
    public class DeleteCourierServiceZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
