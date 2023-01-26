using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Couriers;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.Weights.Queries
{
    public class GetWeightByIdQuery : IRequest<WeightDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetWeightByIdQuery, WeightDto>
        {
            private readonly IReadRepository<Weight> _weightReadRepository;

            public Handler(IReadRepository<Weight> weightReadRepository)
            {
                _weightReadRepository = weightReadRepository;
            }

            public async Task<WeightDto> Handle(GetWeightByIdQuery request, CancellationToken cancellationToken)
            {
                var weight = await _weightReadRepository.Table
                    .Select(c => new WeightDto
                    {
                        Id = c.Id,
                        PostageWeight = c.PostageWeight,
                        Code = c.Code
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return weight;
            }
        }
    }
}