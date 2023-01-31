﻿using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.ValueAddedPrices
{
    public class PostexCod : BaseEntity<int>
    {
        public string Name { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public int FixedValue { get; set; }
        public int FixedPercent { get; set; }
    }
}