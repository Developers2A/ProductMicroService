using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Commands.CreateOrder
{
    public class CreateOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public int ServiceId { get; set; }
        public string ParcelId { get; set; }
        public string Content { get; set; }
        public int ApproximateValue { get; set; }
        public int CodPrice { get; set; }
        public int Weight { get; set; }
        public bool NeedCarton { get; set; }
        public string CartonSizeName { get; set; }
        public string SenderFristName { get; set; }
        public string SenderLastName { get; set; }
        public string SenderMobile { get; set; }
        public string SenderPhone { get; set; }
        public int SenderStateId { get; set; }
        public int SenderCityId { get; set; }
        public string SenderPostCode { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCompany { get; set; }
        public string SenderNationalCode { get; set; }

        public string ReceiverFristName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverPhone { get; set; }
        public int ReceiverStateId { get; set; }
        public int ReceiverCityId { get; set; }
        public string ReceiverPostCode { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverNationalCode { get; set; }
        public string ReceiverCompany { get; set; }
        public bool IsCOD { get; set; }
        public bool HasAccessToPrinter { get; set; }
        public int BoxType { get; set; }
        public int Count { get; set; }
        public string SenderLat { get; set; }
        public string SenderLon { get; set; }
        public string Reciverlat { get; set; }
        public string Reciverlon { get; set; }
        public bool NotifBySms { get; set; }
        public bool IsFreePost { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
    }
}
