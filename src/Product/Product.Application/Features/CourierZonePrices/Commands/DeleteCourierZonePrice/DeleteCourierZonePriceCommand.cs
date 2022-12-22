using Product.Application.Contracts;

namespace Product.Application.Features.CourierZonePrices.Commands.DeleteCourierZonePrice
{
    public class DeleteCourierZonePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
