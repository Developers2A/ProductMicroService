using System;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroGetOrdersResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SellerTrackCode { get; set; }
        public string SellerCustomerName { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public string OrderAddress { get; set; }
        public string LandlineNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime PickUpDate { get; set; }
        public string DeliveryImageUrl { get; set; }
        public int OrderStatus { get; set; }
        public int DeliveryCost { get; set; }
        public int OrderValue { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string PostId { get; set; }
        public string CancelReasonText { get; set; }
    }
}
