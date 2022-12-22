using Product.Application.Contracts;
using Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrice;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateCourierZonePrices
{
    public class CreateCourierZonePricesCommand : ITransactionRequest
    {
        public List<CreateCourierZonePriceCommand> CourierZonePrices { get; set; }
    }
}
