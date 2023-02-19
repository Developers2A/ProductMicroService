﻿using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.Product.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.CreateContractItemType
{
    public class CreateContractItemTypeCommandHandler : IRequestHandler<CreateContractItemTypeCommand, ContractItemType>
    {
        private readonly IWriteRepository<ContractItemType> _writeRepository;
        private readonly IMapper _mapper;

        public CreateContractItemTypeCommandHandler(IWriteRepository<ContractItemType> contratcItemTypeWriteRepository, IMapper mapper)
        {
            this._writeRepository = contratcItemTypeWriteRepository;
            this._mapper = mapper;
        }

        //public async Task<Unit> Handle(CreateContractItemTypeCommand request, CancellationToken cancellationToken)
        //{
        //    //var contractItemType = _mapper.Map<ContractItemType>(request);
        //    var contractItemType = new ContractItemType
        //    {
        //        ContractTypeCode = request.ContractTypeCode,
        //        ContractTypeName = request.ContractTypeName
        //    };
        //    await _writeRepository.AddAsync(contractItemType, cancellationToken);
        //    await _writeRepository.SaveChangeAsync(cancellationToken);
        //    return Unit.Value;
        //}

        async  Task<ContractItemType> IRequestHandler<CreateContractItemTypeCommand, ContractItemType>.Handle(CreateContractItemTypeCommand request, CancellationToken cancellationToken)
        {
            var contractItemType = new ContractItemType
            {
                ContractTypeCode = request.ContractTypeCode,
                ContractTypeName = request.ContractTypeName
            };
            await _writeRepository.AddAsync(contractItemType, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return contractItemType;
        }
    }
}
