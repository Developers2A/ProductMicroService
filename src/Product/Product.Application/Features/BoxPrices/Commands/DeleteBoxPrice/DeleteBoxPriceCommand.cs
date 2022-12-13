using Product.Application.Contracts;

namespace Product.Application.Features.BoxPrices.Commands.DeleteBoxPrice
{
    public class DeleteBoxPriceCommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
