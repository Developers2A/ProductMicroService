using MediatR;
using Postex.Product.Application.Dtos.Commons.GetPrice.Request;
using Postex.Product.Application.Dtos.ServiceProviders.Common;

namespace Postex.Product.Application.Features.CourierZonePrices.Queries.GetOfflinePrices
{
    public class GetOfflinePricesQuery : IRequest<GetQuickPriceResponse>
    {
        public CourierInfoDto Courier { get; set; }
        public SenderReceiverInfoDto Sender { get; set; }
        public SenderReceiverInfoDto Receiver { get; set; }
        public ParcelInfoDto Parcel { get; set; }
        public bool HasCollection { get; set; }
        public bool HasDistribution { get; set; }
        public List<int> ValueAddedTypeIds { get; set; }
    }
}