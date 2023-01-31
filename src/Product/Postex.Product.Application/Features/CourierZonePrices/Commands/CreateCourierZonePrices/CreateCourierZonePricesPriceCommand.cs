using Postex.Product.Application.Contracts;
using Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;

namespace Postex.Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices
{
    public class CreateCourierZonePricesCommand : ITransactionRequest
    {
        public List<CreateCourierZonePriceCommand> CourierZonePrices { get; set; }
    }
}
