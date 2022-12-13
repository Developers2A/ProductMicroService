using Product.Application.Contracts;

namespace Product.Application.Features.CourierZoneSLAs.Commands.DeleteCourierZoneSLA
{
    public class DeleteCourierZoneSLACommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
