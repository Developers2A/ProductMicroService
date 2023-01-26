using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.CourierCods.Queries
{
    public class GetCourierCodsQuery : IRequest<List<CourierCodDto>>
    {
        public class Handler : IRequestHandler<GetCourierCodsQuery, List<CourierCodDto>>
        {
            private readonly IReadRepository<CourierCod> _courierCodReadRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<CourierCod> courierCodReadRepository, IMapper mapper)
            {
                _courierCodReadRepository = courierCodReadRepository;
                _mapper = mapper;
            }

            public async Task<List<CourierCodDto>> Handle(GetCourierCodsQuery request, CancellationToken cancellationToken)
            {
                var courierCods = await _courierCodReadRepository.TableNoTracking
                    .OrderByDescending(c => c.Id).ToListAsync(cancellationToken);
                return _mapper.Map<List<CourierCodDto>>(courierCods);
            }
        }
    }
}