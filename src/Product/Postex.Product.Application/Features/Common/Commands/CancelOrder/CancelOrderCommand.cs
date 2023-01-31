using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CancelOrder
{
    public class CancelOrderCommand : ITransactionRequest<BaseResponse<CancelOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
