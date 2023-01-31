using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostexCods.Commands.CreatePostexCod
{
    public class CreatePostexCodCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public int CourierId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
