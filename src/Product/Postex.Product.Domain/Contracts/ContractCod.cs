﻿using Postex.SharedKernel.Domain;

namespace Postex.Product.Domain.Contracts;

public class ContractCod : BaseEntity<int>
{
    public ContractInfo ContractInfo { get; set; }
    public int ContractInfoId { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public double FixedPercent { get; set; }
    public int FixedValue { get; set; }
    public string? Description { get; set; }
    public bool IsActice { get; set; }
}

