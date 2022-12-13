using Product.Application.Contracts;

namespace Product.Application.Features.PostexCods.Commands.DeletePostexCod
{
    public class DeletePostexCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
