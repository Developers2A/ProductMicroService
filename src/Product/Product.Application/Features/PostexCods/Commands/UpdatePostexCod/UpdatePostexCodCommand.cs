using Product.Application.Contracts;

namespace Product.Application.Features.PostexCods.Commands.UpdatePostexCod
{
    public class UpdatePostexCodCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourierId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
