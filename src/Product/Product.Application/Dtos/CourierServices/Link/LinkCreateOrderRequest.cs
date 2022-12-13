using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Application.Dtos.CourierServices.Link
{
    public class LinkCreateOrderRequest
    {
        [JsonProperty("orderCode")]
        public string OrderCode { get; set; }

        [JsonProperty("items")]
        public List<LinkOrder> Orders { get; set; }


        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (Orders.Any(x => x.SendDate.Date <= DateTime.Today.Date))
            {
                status = false;
                message = "SendDate must be greater than today. ";
            }
            if (Orders.Any(x => x.CompanyTrackingCode == null || x.CompanyTrackingCode == ""))
            {
                status = false;
                message += "CompanyTrackingCode is required. ";
            }
            if (Orders.Any(x => x.Address == null || x.Address == ""))
            {
                status = false;
                message += "Address is required. ";
            }
            if (Orders.Any(x => x.FullName == null || x.FullName == ""))
            {
                status = false;
                message += "Fullname is required. ";
            }
            if (Orders.Any(x => x.City == null || x.City == ""))
            {
                status = false;
                message += "City is required. ";
            }
            if (Orders.Any(x => x.Weight <= 0))
            {
                status = false;
                message += "Weight must be greater than zero. ";
            }

            if (Orders.Any(x => x.ParcelType < 1 || x.ParcelType > 5))
            {
                status = false;
                message += "ParcelType should be 1,2,3,4,5. ";
            }

            if (Orders.Any(x => x.DeliveryType < 1 || x.DeliveryType > 5))
            {
                status = false;
                message += "DeliveryType should be 1,2,3,4,5. ";
            }

            if (Orders.Any(x => x.Shift < 1 || x.Shift > 5))
            {
                status = false;
                message += "Shift should be 1,2,3. ";
            }

            if (Orders.Any(x => x.PType < 1 || x.PType > 5))
            {
                status = false;
                message += "PType should be 1,2,3. ";
            }

            return (status, message);
        }
    }

    public class LinkOrder
    {
        [JsonProperty("companyTrackingCode")]
        public string CompanyTrackingCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("deliveryType")]
        public int DeliveryType { get; set; }

        [JsonProperty("shift")]
        public int Shift { get; set; }

        [JsonProperty("parcelType")]
        public int ParcelType { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("sendDate")]
        public DateTime SendDate { get; set; }

        [JsonProperty("cellPhone")]
        public string CellPhone { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("parcelValue")]
        public decimal ParcelValue { get; set; }

        [JsonProperty("weight")]
        public decimal? Weight { get; set; }

        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        [JsonProperty("return")]
        public int Return { get; set; }

        [JsonProperty("describtion")]
        public string Describtion { get; set; }

        [JsonProperty("senderAddress")]
        public string SenderAddress { get; set; }

        [JsonProperty("generateBarcode")]
        public int GenerateBarcode { get; set; }

        [JsonProperty("Ptype")]
        public int PType { get; set; } = 1;
    }
}
