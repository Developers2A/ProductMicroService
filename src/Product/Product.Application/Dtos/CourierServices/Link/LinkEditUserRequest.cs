﻿namespace Product.Application.Dtos.CourierServices.Link
{
    public class LinkEditUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string AddressCity { get; set; }
        public string Address { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyEconomicCode { get; set; }
        public string AddressFullName { get; set; }
        public string AddressCellPhone { get; set; }

        public (bool, string) IsValidRequest()
        {
            bool status = true;
            string message = "";

            if (string.IsNullOrEmpty((FirstName ?? "").Trim()))
            {
                status = false;
                message += "FirstName is required. ";
            }
            if (string.IsNullOrEmpty((LastName ?? "").Trim()))
            {
                status = false;
                message += "LastName is required. ";
            }
            if (string.IsNullOrEmpty((CellPhone ?? "").Trim()))
            {
                status = false;
                message += "CellPhone is required. ";
            }
            if (string.IsNullOrEmpty((Email ?? "").Trim()))
            {
                status = false;
                message += "Email is required. ";
            }
            if (string.IsNullOrEmpty((Address ?? "").Trim()))
            {
                status = false;
                message += "Address is required. ";
            }
            if (string.IsNullOrEmpty((AddressFullName ?? "").Trim()))
            {
                status = false;
                message += "AddressFullName is required. ";
            }
            if (string.IsNullOrEmpty((AddressCellPhone ?? "").Trim()))
            {
                status = false;
                message += "AddressCellPhone is required. ";
            }
            return (status, message);
        }
    }
}
