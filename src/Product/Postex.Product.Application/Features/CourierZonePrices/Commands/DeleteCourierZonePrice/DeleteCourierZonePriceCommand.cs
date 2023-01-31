using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.DeleteCourierZonePrice
{
    public class DeleteCourierZonePriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
