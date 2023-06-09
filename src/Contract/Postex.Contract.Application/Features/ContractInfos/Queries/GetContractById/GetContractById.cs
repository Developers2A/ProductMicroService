﻿using MediatR;
using Postex.Contract.Application.Dtos;

namespace Postex.Contract.Application.Features.ContractInfos.Queries.GetContractById
{
    public class GetContractById : IRequest<ContractInfoDto>
    {
        public int Id { get; set; }
    }
}
