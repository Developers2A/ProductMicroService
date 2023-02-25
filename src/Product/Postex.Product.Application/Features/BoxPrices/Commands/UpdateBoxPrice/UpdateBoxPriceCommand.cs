using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxPrices.Commands.UpdateBoxPrice
{
    public class UpdateBoxPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public int BoxTypeId { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
