using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Request;
using Postex.Product.Application.Dtos.Commons.CreateParcel.Response;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommand : ITransactionRequest<BaseResponse<CreateParcelResponseDto>>
    {
        public SenderReceiverDto From { get; set; }
        public SenderReceiverDto To { get; set; }
        public ParcelDto Parcel { get; set; }
        public CourierDto Courier { get; set; }
        public List<int> ValueAddedTypeIds { get; set; }
        public DeliveryPickupDto Pickup { get; set; }
        public DeliveryPickupDto Delivery { get; set; }
    }
}
