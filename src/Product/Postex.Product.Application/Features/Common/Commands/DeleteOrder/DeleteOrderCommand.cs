using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ITransactionRequest<BaseResponse<DeleteOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
