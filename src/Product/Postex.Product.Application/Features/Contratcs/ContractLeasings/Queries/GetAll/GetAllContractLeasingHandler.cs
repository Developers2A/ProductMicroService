using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postex.SharedKernel.Utilities;
using Postex.Product.Domain.Contracts;
using Postex.Product.Application.Dtos.Contratcs;

namespace Postex.Product.Application.Features.Contratcs.ContractLeasings.Queries.GetAll
{
    public class GetAllContractLeasingHandler : IRequestHandler<GetAllContractLeasingCommand, List<ContractLeasingDto>>
    {
        private readonly IReadRepository<ContractLeasing> readRepository;

        public GetAllContractLeasingHandler(IReadRepository<ContractLeasing> readRepository)
        {
            this.readRepository = readRepository;
        }
        public async Task<List<ContractLeasingDto>> Handle(GetAllContractLeasingCommand request, CancellationToken cancellationToken)
        {
            PersianCalendar pc = new();

            var items = await readRepository.Table.Select
                (c => new ContractLeasingDto
                {
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    Amount = c.Amount,
                    ReturnRate = c.ReturnRate,
                    WithdrawRate = c.WithdrawRate,
                    DailyDepositRateCeiling = c.DailyDepositRateCeiling,
                    DailyDepositeRate = c.DailyDepositeRate,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    EndDate = c.EndDate,
                    StartDate = c.StartDate,
                }
                ).ToListAsync(cancellationToken);

            foreach (var item in items)
            {
                var date = item.StartDate;
                date.ToPersianDate();
            }
            return items;
        }
    }
}
