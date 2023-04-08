namespace Postex.Product.Application.Dtos.ServiceProviders.Post
{
    public class PostEditWeightResponse
    {
        public int PostFare { get; set; }
        public int InsurancePrice { get; set; }
        public int SendPlacePrice { get; set; }
        public int NonStandardPrice { get; set; }
        public int SMSPrice { get; set; }
        public int COD { get; set; }
        public int DeliveryNotifyPrice { get; set; }
        public int PostPayFarePrice { get; set; }
        public int ElectronicIDPrice { get; set; }
        public int PostPrice { get; set; }
        public int DiscountPercent { get; set; }
        public int DiscountAmount { get; set; }
        public int EcommercePrice { get; set; }
        public int Tax { get; set; }
        public int TotalPrice { get; set; }
        public int ReturnPrice { get; set; }
        public int ReturnTax { get; set; }
    }
}
