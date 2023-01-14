using Postex.SharedKernel.Common.Enums;

namespace Product.Application.Dtos.CollectionDistributions
{
    public class BasketSumDto
    {
        public int Volume { get; set; }
        public int CityTypeId { get; set; }
        public ServiceType ServiceId { get; set; }
        public CourierCode Courier { get; set; }
        public string ShipmentId { get; set; }
        public string CommentCollection { get; set; }
        public string CommentDistribution { get; set; }
    }
}