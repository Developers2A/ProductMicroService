using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.ServiceProviders.Common.Commands.CancelOrder
{
    public class CancelOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public int CourierCode { get; set; }
        public List<string> TrackCodes { get; set; }
    }
}
