using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos.CourierServices.Common;
using Postex.SharedKernel.Common;

namespace Postex.Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public string? UserName { get; set; }
        public int CourierServiceCode { get; set; }
        public int PayType { get; set; }
        public string? ParcelId { get; set; }
        public int? BoxSize { get; set; }
        public string? Content { get; set; }
        public int ApproximateValue { get; set; }
        public int Weight { get; set; }
        public string? SenderFristName { get; set; }
        public string? SenderLastName { get; set; }
        public string? SenderMobile { get; set; }
        public string? SenderPhone { get; set; }
        public int SenderCityCode { get; set; }
        public string? SenderPostCode { get; set; }
        public string? SenderAddress { get; set; }
        public string? SenderCompany { get; set; }
        public string? SenderNationalCode { get; set; }
        public string? SenderLat { get; set; }
        public string? SenderLon { get; set; }
        public string? SenderEmail { get; set; }
        public string? ReceiverFristName { get; set; }
        public string? ReceiverLastName { get; set; }
        public string? ReceiverMobile { get; set; }
        public string? ReceiverPhone { get; set; }
        public int ReceiverCityCode { get; set; }
        public string? ReceiverPostCode { get; set; }
        public string? ReceiverAddress { get; set; }
        public string? ReceiverEmail { get; set; }
        public string? ReceiverNationalCode { get; set; }
        public string? ReceiverCompany { get; set; }
        public string? ReceiverLat { get; set; }
        public string? ReceiverLon { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PickupDate { get; set; }
        public bool IsLiquidOrBroken { get; set; }
    }
}
