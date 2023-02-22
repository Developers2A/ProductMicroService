﻿using AutoMapper;
using MediatR;
using Postex.Product.Application.Dtos;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractCods.Command.Update
{
    public class UpdateContractCodCommandHandler : IRequestHandler<UpdateContractCodCommand, ContractCodDto>
    {
        private readonly IWriteRepository<ContractCod> _writeRepository;
        private readonly IReadRepository<ContractCod> _readRepository;
        private readonly IMapper _mapper;

        public UpdateContractCodCommandHandler(IWriteRepository<ContractCod> writeRepository, IReadRepository<ContractCod> readRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
        }
       

     async   Task<ContractCodDto> IRequestHandler<UpdateContractCodCommand, ContractCodDto>.Handle(UpdateContractCodCommand request, CancellationToken cancellationToken)
        {
            ContractCod contractCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (contractCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            contractCod.FromValue = request.FromValue;
            contractCod.ToValue = request.ToValue;
            contractCod.FixedValue = request.FixedValue;
            contractCod.FixedPercent = request.FixedPercent;
            contractCod.Description = request.Description;

            await _writeRepository.UpdateAsync(contractCod);
            await _writeRepository.SaveChangeAsync();
            var dto = _mapper.Map<ContractCodDto>(contractCod);
            return dto;
        }
    }
}
