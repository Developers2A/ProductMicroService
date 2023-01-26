using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostexCods.Commands.DeletePostexCod
{
    public class DeletePostexCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
