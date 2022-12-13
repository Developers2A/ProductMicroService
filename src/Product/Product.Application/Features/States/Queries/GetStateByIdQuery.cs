using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.States.Queries
{
    public class GetStateByIdQuery : IRequest<StateDto>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetStateByIdQuery, StateDto>
        {
            private readonly IReadRepository<State> _stateRepository;

            public Handler(IReadRepository<State> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<StateDto> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
            {
                var state = await _stateRepository.Table
                    .Select(c => new StateDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = c.Code,
                        EnglishName = c.EnglishName
                    })
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                return state;
            }
        }
    }
}