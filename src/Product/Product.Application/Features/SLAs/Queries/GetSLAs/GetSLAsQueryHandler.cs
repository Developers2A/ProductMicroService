using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.SLAs.Queries.GetSLAs
{
    public class GetSLAsQueryHandler : IRequestHandler<GetSLAsQuery, List<SLADto>>
    {
        private readonly IReadRepository<SLA> _slaReadRepository;

        public GetSLAsQueryHandler(IReadRepository<SLA> slaReadRepository)
        {
            _slaReadRepository = slaReadRepository;
        }

        public async Task<List<SLADto>> Handle(GetSLAsQuery request, CancellationToken cancellationToken)
        {
            var slas = await _slaReadRepository.TableNoTracking
                .Select(c => new SLADto
                {
                    Id = c.Id,
                    Name = c.Name,
                    CourierId = c.CourierId,
                    Days = c.Days
                })
                .OrderByDescending(c => c.Id)
                .ToListAsync(cancellationToken);

            return slas;
        }
    }

}