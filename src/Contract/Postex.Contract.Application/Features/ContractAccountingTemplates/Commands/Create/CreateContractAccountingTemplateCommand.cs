﻿using Postex.Contract.Application.Contracts;
using Postex.Contract.Domain;

namespace Postex.Contract.Application.Features.ContractAccountingTemplates.Commands.Create
{
    public class CreateContractAccountingTemplateCommand: ITransactionRequest
    {
        public int ContractInfoId { get; set; }
        public string ContractDetailType { get; set; }
        public int ContractDetailId { get; set; }
        public int CustomerId { get; set; }
        public double PercentValue { get; set; }
        public int FixedValue { get; set; }
        public string Description { get; set; }
    }
}
