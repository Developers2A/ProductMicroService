using Product.Application.Contracts;

namespace Product.Application.Features.CourierCods.Commands.DeleteCourierCod
{
    public class DeleteCourierCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
