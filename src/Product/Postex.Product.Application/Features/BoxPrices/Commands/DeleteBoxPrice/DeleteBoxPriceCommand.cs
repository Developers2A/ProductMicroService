using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxPrices.Commands.DeleteBoxPrice
{
    public class DeleteBoxPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
