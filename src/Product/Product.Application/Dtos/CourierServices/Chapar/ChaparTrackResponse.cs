using System.Collections.Generic;

namespace Product.Application.Dtos.Chapar
{
    public class ChaparTrackResponse
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public Objects Objects { get; set; }
    }

    public class Objects
    {
        public Order Order { get; set; }
    }

    public class ChaparTrackingGeo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }

    public class ChaparTrackingHistory
    {
        public int Timestamp_Date { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public ChaparTrackingGeo Geo { get; set; }
        public string Loc { get; set; }
    }
    public class Order
    {
        public string Delivered_To { get; set; }
        public string Delivery_Time { get; set; }
        public string Signature { get; set; }
        public ChaparTrackingGeo Geo { get; set; }
        public List<ChaparTrackingHistory> History { get; set; }
        public string Origin { get; set; }
        public string Dest { get; set; }
        public string Pickup_Agent_Code { get; set; }
        public string Pickup_Agent { get; set; }
        public string Delivery_Agent_Code { get; set; }
        public string Delivery_Agent { get; set; }
        public string Sender_Code { get; set; }
        public object Sender_Company { get; set; }
        public object Sender_Contact { get; set; }
        public object Sender_Phone { get; set; }
        public object Receiver_Company { get; set; }
        public object Receiver_Contact { get; set; }
        public string Receiver_Phone { get; set; }
    }
}