using Product.Application.Contracts;

namespace Product.Application.Features.SLAs.Commands.UpdateSLA
{
    public class UpdateSLACommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Days { get; set; }
    }
}
