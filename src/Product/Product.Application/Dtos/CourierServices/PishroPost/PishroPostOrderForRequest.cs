namespace Product.Application.Dtos.CourierServices.PishroPost
{
    public class PishroPostOrderForRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderValue { get; set; }
        public bool PaymentDeliveryCost { get; set; }
        public bool PaymentOrderValue { get; set; }
        public string PickUpDate { get; set; }
        public bool WorkShift { get; set; }
        public string Token { get; set; }
        public string SenderFirstName { get; set; }
        public string SenderLastName { get; set; }
        public string CompanyName { get; set; }
        public string SenderAddress { get; set; }
        public string SenderCellPhoneNumber { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderNationalCode { get; set; }
        public int SenderLatitude { get; set; }
        public int SenderLongitude { get; set; }
        public string ReceiverFirstName { get; set; }
        public string ReceiverLastName { get; set; }
        public string ReceiverLandlineNumber { get; set; }
        public string ReceiverProvinceName { get; set; }
        public string ReceiverCityName { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverCellPhoneNumber { get; set; }
        public string ReceiverPostalCode { get; set; }
        public int ReceiverLatitude { get; set; }
        public int ReceiverLongitude { get; set; }
        public int DeliveryCost { get; set; }
    }
}
