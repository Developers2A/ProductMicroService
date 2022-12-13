using Product.Application.Contracts;

namespace Product.Application.Features.SLAs.Commands.DeleteSLA
{
    public class DeleteSLACommand : ITransactionRequest
    {
        public int Id { get; set; }
    }
}
