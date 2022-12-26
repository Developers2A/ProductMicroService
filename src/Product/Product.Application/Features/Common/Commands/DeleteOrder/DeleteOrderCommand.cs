using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ITransactionRequest<BaseResponse<DeleteOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
