using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
{
    public class UpdateValueAddedPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int ValueAddedTypeId { get; set; }
    }
}
