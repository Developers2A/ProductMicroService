using Product.Application.Contracts;

namespace Product.Application.Features.Statuses.Commands.UpdateStatus
{
    public class UpdateStatusCommand : ITransactionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }
    }
}
