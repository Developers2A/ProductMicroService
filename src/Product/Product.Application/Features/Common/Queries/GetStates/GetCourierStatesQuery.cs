using AutoMapper;
using MediatR;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Chapar.Queries.GetStates;
using Product.Application.Features.ServiceProviders.Post.Queries.GetStates;
using Product.Application.Features.ServiceProviders.Taroff.Queries.GetStates;

namespace Product.Application.Features.Common.Queries.GetStates
{
    public class GetCourierStatesQuery : IRequest<List<CourierStateDto>>
    {
        public int CourierCode { get; set; }

        public class Handler : IRequestHandler<GetCourierStatesQuery, List<CourierStateDto>>
        {
            private readonly IMapper _mapper;
            private readonly IMediator _mediator;

            public Handler(IMapper mapper, IMediator mediator)
            {
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
                _mediator = mediator;
            }

            public async Task<List<CourierStateDto>> Handle(GetCourierStatesQuery request, CancellationToken cancellationToken)
            {
                if (request.CourierCode == (int)Domain.Enums.CourierCode.Post)
                {
                    var postResponse = await _mediator.Send(new GetPostStatesQuery());
                    if (postResponse.IsSuccess)
                    {
                        return _mapper.Map<List<CourierStateDto>>(postResponse.Data);
                    }
                }
                if (request.CourierCode == (int)Domain.Enums.CourierCode.Chapar)
                {
                    var postResponse = await _mediator.Send(new GetChaparStatesQuery());
                    if (postResponse.IsSuccess)
                    {
                        return _mapper.Map<List<CourierStateDto>>(postResponse.Data);
                    }
                }
                if (request.CourierCode == (int)Domain.Enums.CourierCode.Taroff)
                {
                    var postResponse = await _mediator.Send(new GetTaroffStatesQuery());
                    if (postResponse.IsSuccess)
                    {
                        return _mapper.Map<List<CourierStateDto>>(postResponse.Data);
                    }
                }
                return new List<CourierStateDto>();
            }
        }
    }
}