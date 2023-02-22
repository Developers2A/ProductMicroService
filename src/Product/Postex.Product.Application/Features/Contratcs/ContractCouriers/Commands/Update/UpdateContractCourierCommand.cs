﻿using Postex.Product.Application.Contracts;
using Postex.Product.Application.Dtos;

namespace Postex.Product.Application.Features.ContractCouriers.Command.Update
{
    public class UpdateContractCourierCommand : ITransactionRequest<ContractCourierDto>
    {
        public int Id { get; set; }       
        public int CourierId { get; set; }
        public int FixedDiscount { get; set; }
        public double PercentDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
