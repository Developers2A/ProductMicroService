﻿using Product.Application.Contracts;

namespace Product.Application.Features.CourierZonePrices.Commands.CreateOfflineCourierZonePrice
{
    public class CreateOfflineCourierZonePriceCommand : ITransactionRequest
    {
        public int CourierCode { get; set; }
    }
}
