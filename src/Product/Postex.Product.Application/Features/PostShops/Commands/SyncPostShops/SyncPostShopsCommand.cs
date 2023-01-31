using Postex.Product.Application.Contracts;

namespace Postex.Product.Application.Features.PostShops.Commands.SyncPostShops
{
    public class SyncPostShopsCommand : ITransactionRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
