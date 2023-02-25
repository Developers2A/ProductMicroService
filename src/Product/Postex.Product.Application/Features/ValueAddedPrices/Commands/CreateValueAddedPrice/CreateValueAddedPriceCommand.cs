using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.CreateValueAddedPrice
{
    public class CreateValueAddedPriceCommand : ITransactionRequest
    {
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int ValueAddedTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}
