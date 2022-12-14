namespace Product.Application.Dtos.CourierServices.Common
{
    public class CreateOrderResponse
    {
        public string TrackingNumber { get; set; }
        public int GatewayPostPrice { get; set; }
        public int GatewayPostPriceTax { get; set; }
        public int PostexEngPrice { get; set; }
        public int ShipmentTempId { get; set; }
        public int SmsPrice { get; set; }
        public int AccessPrinterPrice { get; set; }
        public int InsurancePrice { get; set; }
        public int CartonPrice { get; set; }
        public int PrintLogoPrice { get; set; }
        public int RegistrationValue { get; set; }
        public int AgentAddedValue { get; set; }
        public int GoodsCodPrice { get; set; }
        public int ShipmentHagHemaghar { get; set; }
        public int CodTranPrice { get; set; }
        public int DistributionPrice { get; set; }
    }
}
