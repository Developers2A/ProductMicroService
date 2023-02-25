using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxTypes.Commands.DeleteBoxType
{
    public class DeleteBoxTypeCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
