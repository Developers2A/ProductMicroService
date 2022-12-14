using Product.Application.Contracts;

namespace Product.Application.Features.CourierServiceZonePrices.Commands.DeleteCourierServiceZonePrice
{
    public class DeleteCourierServiceZonePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
