using Postex.Product.Application.Contracts;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.Application.Features.ValueAddedPrices.Commands.UpdateValueAddedPrice
{
    public class UpdateValueAddedPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SellPrice { get; set; }
        public decimal BuyPrice { get; set; }
        public ValueAddedType ValueAddedType { get; set; }
    }
}
