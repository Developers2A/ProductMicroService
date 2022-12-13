using System;

namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroGetOrderReportResponse
    {
        public int Status { get; set; }
        public string StatusText { get; set; }
        public DateTime CreatedOn { get; set; }
        public long OrderId { get; set; }
        public string PostCode { get; set; }
        public string ImageUrl { get; set; }
    }
}
