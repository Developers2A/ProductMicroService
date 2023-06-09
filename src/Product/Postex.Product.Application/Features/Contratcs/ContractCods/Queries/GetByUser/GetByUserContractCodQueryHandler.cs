﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCods.Queries.GetByUser
{
    /// <summary>
    /// در قرارداد های پرداخت در محل مشتری درصد مشخصی حق پستکس درنظر گرفته میشود 
    /// همچنین ممکن بر اساس قراردادهایی در یک استان یا شهر خاص ویا حتی برای یک مشتری این عدد حق پستکس تغییر کند  
    /// این متد لیست سطوح مختلف حق پستکس را به عنوان خروجی برمی گرداند
    /// با اولویت  ابتدا قرارداد مشتری ، سپس قرارداد شهر ، بعد از آن قرارداد استان  در اخر قرارداد پیش فرض سطوح قیمت بدست می آید    
    /// در این متد یکی از اولویت ها انتخاب می شود و همه سطوح ان به عنوان خروجی برگشت داده میشود 
    /// </summary>     

    public class GetByUserContractCodQueryHandler : IRequestHandler<GetByUserContractCodQuery, List<ContractCodDto>>
    {
        private readonly IReadRepository<ContractCod> _readRepository;

        public GetByUserContractCodQueryHandler(IReadRepository<ContractCod> readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<List<ContractCodDto>> Handle(GetByUserContractCodQuery request, CancellationToken cancellationToken)
        {
            var codCus = await _readRepository.Table.AsNoTracking()
               .Include(c => c.ContractInfo)
               .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.UserId == request.UserId && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                   LevelPrice = "Customer"
               })
               .ToListAsync(cancellationToken);
            if (codCus.Count != 0)
                return codCus;

            var codCity = await _readRepository.Table
                 .Include(c => c.ContractInfo)
                 .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.CityId == request.CityId && c.ContractInfo.UserId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                     LevelPrice = "City"
                 })
                 .ToListAsync(cancellationToken);
            if (codCity.Count != 0)
                return codCity;

            var codProvince = await _readRepository.Table
                .Include(c => c.ContractInfo)
                .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.ProvinceId == request.ProvinceId && c.ContractInfo.CityId == 0 && c.ContractInfo.UserId == null && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
                    LevelPrice = "Province"
                })
                .ToListAsync(cancellationToken);
            if (codProvince.Count != 0)
                return codProvince;

            var codDefualt = await _readRepository.Table
           .Include(c => c.ContractInfo)
           .Where(c => c.ContractInfo.IsActive == true && c.ContractInfo.UserId == null && c.ContractInfo.CityId == 0 && c.ContractInfo.ProvinceId == 0 && c.ContractInfo.StartDate <= DateTime.Now && c.ContractInfo.EndDate >= DateTime.Now)
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
               LevelPrice = "Default"

           })
           .ToListAsync(cancellationToken);

            return codDefualt;

        }
    }
}
