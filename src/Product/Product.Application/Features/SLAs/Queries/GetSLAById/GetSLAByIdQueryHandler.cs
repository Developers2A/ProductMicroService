using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Couriers;
using Product.Domain.Couriers;

namespace Product.Application.Features.SLAs.Queries.GetSLAById
{
    public class GetSLAByIdQueryHandler : IRequestHandler<GetSLAByIdQuery, SLADto>
    {
        private readonly IReadRepository<SLA> _slaReadRepository;

        public GetSLAByIdQueryHandler(IReadRepository<SLA> slaRepository)
        {
            _slaReadRepository = slaRepository;
        }

        public async Task<SLADto> Handle(GetSLAByIdQuery request, CancellationToken cancellationToken)
        {
            var sla = await _slaReadRepository.TableNoTracking
                .Select(c => new SLADto
                {
                    Id = c.Id,
                    Name = c.Name
                }).FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return sla;
        }
    }
}
