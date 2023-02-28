using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.ReadyOrder
{
    public class ReadyOrderCommand : ITransactionRequest<BaseResponse<ReadyOrderResponse>>
    {
        public int CourierCode { get; set; }
        public string TrackCode { get; set; }
    }
}
