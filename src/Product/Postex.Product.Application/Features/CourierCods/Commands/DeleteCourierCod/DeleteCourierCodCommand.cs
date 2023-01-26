using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.CourierCods.Commands.DeleteCourierCod
{
    public class DeleteCourierCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
