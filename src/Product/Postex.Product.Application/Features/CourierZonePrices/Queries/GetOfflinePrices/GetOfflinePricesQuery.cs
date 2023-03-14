using MediatR;
using Postex.Product.Application.Dtos.ServiceProviders.Common;

namespace Postex.Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices
{
    public class GetOfflinePricesQuery : IRequest<GetQuickPriceResponse>
    {
        public int CourierCode { get; set; } = 0;
        public int ServiceCode { get; set; } = 0;
        public int SenderProvinceCode { get; set; }
        public int SenderCityCode { get; set; }
        public int ReceiverProvinceCode { get; set; }
        public int ReceiverCityCode { get; set; }
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