using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Weights.Queries
{
    public class GetWeightsQuery : IRequest<List<WeightDto>>
    {
        public class Handler : IRequestHandler<GetWeightsQuery, List<WeightDto>>
        {
            private readonly IReadRepository<Weight> _weightReadRepository;

            public Handler(IReadRepository<Weight> weightReadRepository)
            {
                _weightReadRepository = weightReadRepository;
            }

            public async Task<List<WeightDto>> Handle(GetWeightsQuery request, CancellationToken cancellationToken)
            {
                var weights = await _weightReadRepository.TableNoTracking
                    .Select(c => new WeightDto
                    {
                        Id = c.Id,
                        PostageWeight = c.PostageWeight,
                        Code = c.Code
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return weights;
            }
        }
    }
}