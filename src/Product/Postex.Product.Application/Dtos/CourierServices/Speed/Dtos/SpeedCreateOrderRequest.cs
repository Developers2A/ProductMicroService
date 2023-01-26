using Newtonsoft.Json;

namespace Postex.Product.Application.Dtos.CourierServices.Speed.Dtos
{
    public class SpeedCreateOrderRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string CellPhone { get; set; }

        [JsonProperty("addr")]
        public string Address { get; set; }

        [JsonProperty("qty"), JsonRequired]
        public int Qty { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("vol")]
        public int Vol { get; set; }

        [JsonProperty("packing")]
        public string Packing { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("payment")]
        public int Payment { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        [JsonProperty("orderID")]
        public string OrderId { get; set; }

        [JsonProperty("shift")]
        public int Shift { get; set; }

        [JsonProperty("req_date")]
        public string ReqDate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("shipment")]
        public int Shipment { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("order_type")]
        public int OrderType { get; set; }

        [JsonProperty("sender_name")]
        public string SenderName { get; set; }

        [JsonProperty("sender_lastname")]
        public string SenderLastName { get; set; }

        [JsonProperty("sender_city")]
        public string SenderCity { get; set; }

        [JsonProperty("sender_phone")]
        public string SenderPhone { get; set; }

        [JsonProperty("sender_cell")]
        public string SenderCellPhone { get; set; }

        [JsonProperty("sender_addr")]
        public string SenderAddress { get; set; }

        [JsonProperty("sender_location")]
        public string SenderLocation { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((Phone ?? "").Trim()) && string.IsNullOrEmpty((CellPhone ?? "").Trim()))
            {
                status = false;
                message += "Phone Or CellPhone is required. ";
            }
            if (string.IsNullOrEmpty((Address ?? "").Trim()))
            {
                status = false;
                message += "Address is required. ";

            }
            if (string.IsNullOrEmpty((SenderName ?? "").Trim()))
            {
                status = false;
                message += "SenderName is required. ";
            }
            if (string.IsNullOrEmpty((SenderLastName ?? "").Trim()))
            {
                status = false;
                message += "SenderLastName is required. ";
            }
            if (string.IsNullOrEmpty((Content ?? "").Trim()))
            {
                status = false;
                message += "Content is required. ";
            }
            if (string.IsNullOrEmpty((SenderCity ?? "").Trim()))
            {
                status = false;
                message += "SenderCity is required. ";
            }
            if (string.IsNullOrEmpty((SenderPhone ?? "").Trim()) && string.IsNullOrEmpty((SenderCellPhone ?? "").Trim()))
            {
                status = false;
                message += "SenderPhone or SenderCellPhone is required. ";
            }

            if (string.IsNullOrEmpty((SenderAddress ?? "").Trim()))
            {
                status = false;
                message += "SenderAddress is required. ";
            }
            //if (string.IsNullOrEmpty((SenderLocation ?? "").Trim()))
            //{
            //    status = false;
            //    message += "SenderLocation is required. ";
            //}
            if (string.IsNullOrEmpty((Name ?? "").Trim()))
            {
                status = false;
                message += "Name is required. ";
            }
            if (string.IsNullOrEmpty((LastName ?? "").Trim()))
            {
                status = false;
                message += "LastName is required. ";
            }

            if (string.IsNullOrEmpty((City ?? "").Trim()))
            {
                status = false;
                message += "City is required. ";
            }

            if (Weight <= 0)
            {
                status = false;
                message += "Weight must be greater than zero. ";
            }

            if (Qty <= 0)
            {
                status = false;
                message += "Qty must be greater than zero. ";
            }

            if (Price <= 0)
            {
                status = false;
                message += "Price must be greater than zero. ";
            }

            if (Vol < 0 || Vol > 1)
            {
                status = false;
                message += "Vol must be 0,1(parcel has valume). ";
            }

            if (Cod < 0 || Cod > 1)
            {
                status = false;
                message += "Cod must be greater 0,1(has Cod). ";
            }

            if (Payment < 0 || Payment > 1)
            {
                status = false;
                message += "Payment must be greater 0(PrePaid),1(PostPaid). ";
            }
            if (Shipment < 0 || Shipment > 1)
            {
                status = false;
                message += "Shipment must be greater 0(Land),1(Air). ";
            }
            if (OrderType < 0 || OrderType > 1)
            {
                status = false;
                message += "OrderType must be greater 0(Distribution),1(Collection). ";
            }
            return (status, message);
        }
    }
}