using Postex.SharedKernel.Common;
using Product.Application.Contracts;
using Product.Application.Dtos.CourierServices.Common;

namespace Product.Application.Features.Common.Queries.GetPrice
{
    public class GetPriceQuery : ITransactionRequest<BaseResponse<GetPriceResponse>>
    {
        public int CourierCode { get; set; } = 0;
        public int ServiceCode { get; set; } = 0;
        public int SenderState { get; set; }
        public int SenderCity { get; set; }
        public int ReceiverCity { get; set; }
        public int ReceiverState { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public bool Sms { get; set; }
        public bool Avatar { get; set; }
        public bool Print { get; set; }
        public bool HasCollection { get; set; }
        public bool HasDistribution { get; set; }
    }
}
