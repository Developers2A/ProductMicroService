using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommand : ITransactionRequest
    {
        public int BoxTypeId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
