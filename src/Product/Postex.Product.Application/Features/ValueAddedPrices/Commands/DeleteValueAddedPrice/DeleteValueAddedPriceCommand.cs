using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.DeleteValueAddedPrice
{
    public class DeleteValueAddedPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
