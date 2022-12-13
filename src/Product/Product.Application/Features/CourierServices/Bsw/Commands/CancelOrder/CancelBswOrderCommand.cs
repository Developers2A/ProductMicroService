using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Bsw;

namespace Product.Application.Features.CourierServices.Bsw.Commands.CancelOrder
{
    public class CancelBswOrderCommand : ITransactionRequest<BaseResponse<BswCancelResponse>>
    {
        public string OrderNumber { get; set; }
    }
}
