using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.ServiceProviders.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public int CourierServiceCode { get; set; }
        public string? ParcelId { get; set; }
        public string? Content { get; set; }
        public int ApproximateValue { get; set; }
        public int Weight { get; set; }
        public SenderDto Sender { get; set; }
        public ReceiverDto Receiver { get; set; }
        public int PayType { get; set; }
        public int? BoxSize { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PickupDate { get; set; }
    }
}
