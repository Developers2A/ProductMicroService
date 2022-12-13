using Product.Application.Contracts;

namespace Product.Application.Features.CourierCods.Commands.CreateCourierCod
{
    public class CreateCourierCodCommand : ITransactionRequest
    {
        public string Name { get; set; }
        public int CourierId { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}
