using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZones.Commands.DeleteCourierZone
{
    public class DeleteCourierZoneCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
