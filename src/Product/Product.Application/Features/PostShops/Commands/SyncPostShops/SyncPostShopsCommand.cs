using Product.Application.Contracts;

namespace Product.Application.Features.PostShops.Commands.SyncPostShops
{
    public class SyncPostShopsCommand : ITransactionRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
