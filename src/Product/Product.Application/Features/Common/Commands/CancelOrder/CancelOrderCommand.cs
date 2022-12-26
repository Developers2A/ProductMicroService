using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Commands.CancelOrder
{
    public class CancelOrderCommand : ITransactionRequest<BaseResponse<CancelOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
