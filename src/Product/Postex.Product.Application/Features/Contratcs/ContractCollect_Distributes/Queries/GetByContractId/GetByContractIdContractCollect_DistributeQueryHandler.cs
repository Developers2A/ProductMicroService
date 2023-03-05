using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Contratcs;
using Postex.Product.Domain.Contracts;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Contratcs.ContractCollect_Distributes.Queries.GetByContractId
{
    public class GetByContractIdContractCollect_DistributeQueryHandler : IRequestHandler<GetByContractIdContractCollect_DistributeQuery, List<ContractCollectionDistributionDto>>
    {
        private readonly IReadRepository<ContractCollectionDistribution> _readRepository;

        public GetByContractIdContractCollect_DistributeQueryHandler(IReadRepository<ContractCollectionDistribution> readRepository)
        {
            _readRepository = readRepository;
        }
        /// <summary>
        /// قیمت توزیع و جمع آوری بر اساس نوع شهر ونوع کارتن متفاوت خواهد بود و این قیمت از سرویس مخصوص توزیع و جمع آوری بدست می آید
        /// در این بخش ما ممکن است برای یک مشتری خاص یا یک شهر و با یک استان بخواهیم قیمت توزیع و جمع آوری را بر اساس نوع کارتن ها مختلف تغییر دهیم
        /// 
        /// در این متد بر اساس شناسه قرارداد ، لیست قیمت های ثبت شده توزیع و یا جمع آوری برای انواع اندازه های کارتن بدست می آید
        /// </summary>
        /// <param name="شناسه قرارداد"></param>
        public async Task<List<ContractCollectionDistributionDto>> Handle(GetByContractIdContractCollect_DistributeQuery request, CancellationToken cancellationToken)
        {
            var collect_Distribute = await _readRepository.Table.Include(b => b.BoxType)
                .Select(c => new ContractCollectionDistributionDto
                {
                    Id = c.Id,
                    ContractInfoId = c.ContractInfoId,
                    BoxTypeId = c.BoxTypeId,
                    CourierServiceId = c.CourierServiceId,
                    CityId = c.CityId,
                    ProvinceId = c.StateId,
                    SalePrice = c.SalePrice,
                    BuyPrice = c.BuyPrice,
                    BoxName = c.BoxType.Name,
                    Height = c.BoxType.Height,
                    Width = c.BoxType.Width,
                    Length = c.BoxType.Length,
                    Description = c.Description,
                    IsActice = c.IsActice,
                })
                .Where(c => c.ContractInfoId == request.ContractInfoId)
                .ToListAsync(cancellationToken);
            return collect_Distribute;
        }
    }
}
