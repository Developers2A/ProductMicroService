using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Bsw;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.ServiceProviders.Bsw.Commands.CancelOrder
{
    public class CancelBswOrderCommand : ITransactionRequest<BaseResponse<BswCancelResponse>>
    {
        public string OrderNumber { get; set; }
    }
}
