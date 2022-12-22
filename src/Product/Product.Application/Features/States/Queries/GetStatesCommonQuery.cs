using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.States.Queries
{
    public class GetStatesCommonQuery : IRequest<List<StateCommonDto>>
    {
        public class Handler : IRequestHandler<GetStatesCommonQuery, List<StateCommonDto>>
        {
            private readonly IReadRepository<State> _stateRepository;

            public Handler(IReadRepository<State> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<List<StateCommonDto>> Handle(GetStatesCommonQuery request, CancellationToken cancellationToken)
            {
                var states = await _stateRepository.Table
                    .Select(c => new StateCommonDto
                    {
                        Code = c.Code,
                        Name = c.Name,
                    })
                    .ToListAsync(cancellationToken);

                return states;
            }
        }
    }
}