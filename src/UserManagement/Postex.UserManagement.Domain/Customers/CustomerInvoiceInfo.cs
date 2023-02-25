﻿using Postex.SharedKernel.Domain;

namespace Postex.UserManagement.Domain.Customers
{
    public class CustomerInvoiceInfo : BaseEntity<int>
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AddressId { get; set; }
        public int TelNo { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
    }
}