using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneSLAPrices.Commands.DeleteCourierZoneSLAPrice
{
    public class DeleteCourierZoneSLAPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
