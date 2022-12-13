using Product.Application.Contracts;

namespace Product.Application.Features.SLAs.Commands.CreateSLA
{
    public class CreateSLACommand : ITransactionRequest
    {
        public int CourierId { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
