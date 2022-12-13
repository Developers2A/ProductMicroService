using Product.Application.Contracts;

namespace Product.Application.Features.ValueAddedPrices.Commands.DeleteValueAddedPrice
{
    public class DeleteValueAddedPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
