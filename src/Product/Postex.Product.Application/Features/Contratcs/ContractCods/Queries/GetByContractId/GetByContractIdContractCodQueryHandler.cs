using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByContractId
{
    public class GetByContractIdContractCodQueryHandler : IRequestHandler<GetByContractIdContractCodQuery, List<ContractCodDto>>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByContractIdContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            _readRepository = readRepository;
        }
        /// <summary>
        /// در این متد بر اساس شناسه قرارداد همه اطلاعات و سطوح مشخص شده برای حق پرداخت در محل پستکس بدست می آید
        /// </summary>
        /// <param name="شناسه قرارداد "></param>      
        /// <returns></returns>
        public async Task<List<ContractCodDto>> Handle(GetByContractIdContractCodQuery request, CancellationToken cancellationToken)
        {
            var cod = await _readRepository.Table
                .Select(c => new ContractCodDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,                 
                    FromValue = c.FromValue,
                    ToValue = c.ToValue,
                    FixedPercent = c.FixedPercent,
                    FixedValue = c.FixedValue,
                    Description = c.Description,
                    IsActice = c.IsActice,
                })
                .ToListAsync(cancellationToken);
            return cod;
        }
    }

}
