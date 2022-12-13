﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.SharedKernel.Interfaces;
using Product.Application.Dtos.Commons;
using Product.Domain.Locations;

namespace Product.Application.Features.States.Queries
{
    public class GetStatesQuery : IRequest<List<StateDto>>
    {
        public class Handler : IRequestHandler<GetStatesQuery, List<StateDto>>
        {
            private readonly IReadRepository<State> _stateRepository;

            public Handler(IReadRepository<State> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            public async Task<List<StateDto>> Handle(GetStatesQuery request, CancellationToken cancellationToken)
            {
                var states = await _stateRepository.Table
                    .Select(c => new StateDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        EnglishName = c.EnglishName,
                        Code = c.Code
                    })
                    .OrderByDescending(c => c.Id)
                    .ToListAsync(cancellationToken);

                return states;
            }
        }
    }
}