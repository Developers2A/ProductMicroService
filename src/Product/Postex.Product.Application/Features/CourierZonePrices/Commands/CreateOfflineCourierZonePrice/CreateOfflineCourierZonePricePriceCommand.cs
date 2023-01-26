using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateOfflineCourierZonePriceCommand : ITransactionRequest
    {
        public int CourierCode { get; set; }
    }
}
