using AutoMapper;
using MediatR;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.CourierServices.Chapar.Queries.GetStates;
using Product.Application.Features.CourierServices.Post.Queries.GetStates;
using Product.Application.Features.CourierServices.Taroff.Queries.GetStates;
using Product.Domain.Enums;

namespace Product.Application.Features.CourierServices.Common.Queries.GetStates
{
    public class GetCourierStatesQuery : IRequest<List<CourierStateDto>>
    {
        public int CourierId { get; set; }

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
                if (request.CourierId == (int)CourierCode.Post)
                {
                    var postResponse = await _mediator.Send(new GetPostStatesQuery());
                    if (postResponse.IsSuccess)
                    {
                        return _mapper.Map<List<CourierStateDto>>(postResponse.Data);
                    }
                }
                if (request.CourierId == (int)CourierCode.Chapar)
                {
                    var postResponse = await _mediator.Send(new GetChaparStatesQuery());
                    if (postResponse.IsSuccess)
                    {
                        return _mapper.Map<List<CourierStateDto>>(postResponse.Data);
                    }
                }
                if (request.CourierId == (int)CourierCode.Taroff)
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