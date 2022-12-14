using AutoMapper;
using MediatR;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.CourierServices.Chapar.Queries.GetCities;
using Product.Application.Features.CourierServices.Post.Queries.GetCities;
using Product.Application.Features.CourierServices.Taroff.Queries.GetCities;
using Product.Domain.Enums;

namespace Product.Application.Features.ServiceProviders.Common.Queries.GetCities
{

    public class GetCourierCitiesQueryHandler : IRequestHandler<GetCourierCitiesQuery, List<CourierCityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetCourierCitiesQueryHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator;
        }

        public async Task<List<CourierCityDto>> Handle(GetCourierCitiesQuery request, CancellationToken cancellationToken)
        {
            if (request.CourierId == (int)CourierCode.Post)
            {
                var postResponse = await _mediator.Send(new GetPostCitiesQuery()
                {
                    ProvinceId = request.StateId
                });
                if (postResponse.IsSuccess)
                {
                    return _mapper.Map<List<CourierCityDto>>(postResponse.Data);
                }
            }
            if (request.CourierId == (int)CourierCode.Chapar)
            {
                var postResponse = await _mediator.Send(new GetChaparCitiesQuery()
                {
                    State = new ChaparGetState()
                    {
                        No = request.StateId
                    }
                });
                if (postResponse.IsSuccess)
                {
                    return _mapper.Map<List<CourierCityDto>>(postResponse.Data);
                }
            }
            if (request.CourierId == (int)CourierCode.Taroff)
            {
                var postResponse = await _mediator.Send(new GetTaroffCitiesQuery()
                {
                    ProvinceId = request.StateId
                });
                if (postResponse.IsSuccess)
                {
                    return _mapper.Map<List<CourierCityDto>>(postResponse.Data);
                }
            }
            return new List<CourierCityDto>();
        }
    }

}