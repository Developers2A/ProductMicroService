using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.ServiceProviders.Common.Commands.CreatePeykOrder
{
    public class CreatePeykOrderCommand : ITransactionRequest<BaseResponse<CreateOrderResponse>>
    {
        public int CourierCode { get; set; }
        public int ShopId { get; set; }
        public string GoodsType { get; set; }
        public int ApproximateValue { get; set; }
        public int CodGoodsPrice { get; set; }
        public int Weight { get; set; }
        public string InsuranceName { get; set; }
        public bool NeedCarton { get; set; }
        public string CartonSizeName { get; set; }
        public string Sender_FristName { get; set; }
        public string Sender_LastName { get; set; }
        public string Sender_Mobile { get; set; }
        public int Sender_StateId { get; set; }
        public int Sender_TownId { get; set; }
        public string Sender_PostCode { get; set; }
        public string Sender_Address { get; set; }
        public string Reciver_FristName { get; set; }
        public string Reciver_LastName { get; set; }
        public string Reciver_Mobile { get; set; }
        public int Reciver_StateId { get; set; }
        public int Reciver_TownId { get; set; }
        public string Reciver_PostCode { get; set; }
        public string Reciver_Address { get; set; }
        public bool IsCOD { get; set; }
        public bool HasAccessToPrinter { get; set; }
        public int BoxType { get; set; }
        public int Count { get; set; }
        public string SenderLat { get; set; }
        public string SenderLon { get; set; }
        public string Reciverlat { get; set; }
        public string Reciverlon { get; set; }
        public string RefrenceNo { get; set; }
        public int OrderSource { get; set; }
        public bool NotifBySms { get; set; }
        public bool IsFreePost { get; set; }
    }
}
