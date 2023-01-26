using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.BoxPrices.Commands.CreateBoxPrice
{
    public class CreateBoxPriceCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
    }
}
