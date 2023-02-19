using AutoMapper;
using MediatR;
using Postex.Product.Domain;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.ContractItemTypes.Commands.DeleteContratcItemType
{
    public class DeleteContractItemTypeCommandHandler : IRequestHandler<DeleteContractItemTypeCommand>
    {
        private readonly IWriteRepository<ContractItemType> contratcItemTypeWriteRepository;
        private readonly IMapper mapper;

        public DeleteContractItemTypeCommandHandler(IWriteRepository<ContractItemType> contratcItemTypeWriteRepository, IMapper mapper)
        {
            this.contratcItemTypeWriteRepository = contratcItemTypeWriteRepository;
            this.mapper = mapper;
        }

        public Task<Unit> Handle(DeleteContractItemTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //public Task<Unit> Handle(DeleteContractItemTypeCommand request, CancellationToken cancellationToken)
        //{
        //    var contractItemType = mapper.Map<ContractItemType>(request);

        //    await contratcItemTypeWriteRepository.AddAsync(contractItemType, cancellationToken);
        //    await contratcItemTypeWriteRepository.SaveChangeAsync(cancellationToken);
        //    return Unit.Value;
        //    return Unit.Value;
        //}
    }
}
