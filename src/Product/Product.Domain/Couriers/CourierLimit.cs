﻿using Postex.SharedKernel.Domain;

namespace Product.Domain.Couriers
{
    public class CourierLimit : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<CourierLimitValue> CourierLimitValues { get; set; }
    }
}
