using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Domain.Common;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostexInsurances.Queries
{
    public class GetPostexInsuranceByIdQuery : IRequest<PostexInsuranceDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetPostexInsuranceByIdQuery, PostexInsuranceDto>
        {
            private readonly IReadRepository<PostexInsurance> _courierInsuranceRepository;
            private readonly IMapper _mapper;

            public Handler(IReadRepository<PostexInsurance> courierInsuranceRepository, IMapper mapper)
            {
                _courierInsuranceRepository = courierInsuranceRepository;
                _mapper = mapper;
            }

            public async Task<PostexInsuranceDto> Handle(GetPostexInsuranceByIdQuery request, CancellationToken cancellationToken)
            {
                var courierInsurance = await _courierInsuranceRepository.TableNoTracking
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
                return _mapper.Map<PostexInsuranceDto>(courierInsurance);
            }
        }
    }
}