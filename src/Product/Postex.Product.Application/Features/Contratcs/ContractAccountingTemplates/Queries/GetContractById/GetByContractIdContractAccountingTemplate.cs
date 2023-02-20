﻿using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;

namespace Postex.Product.Application.Features.ContractAccountingTemplates.Queries.GetContractById
{
    public class GetByContractIdContractAccountingTemplate:IRequest<ContractAccountingTemplate>
    {
        public int ContractInfoId { get; set; }
    }
}
