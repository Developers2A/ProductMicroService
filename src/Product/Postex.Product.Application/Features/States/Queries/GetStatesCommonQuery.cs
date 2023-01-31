using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Domain.Locations;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.States.Queries
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