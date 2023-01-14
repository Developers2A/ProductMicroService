using AutoMapper;
using MediatR;
using Postex.SharedKernel.Common.Enums;
using Product.Application.Dtos.CourierServices.Common;
using Product.Application.Features.ServiceProviders.Chapar.Queries.GetCities;
using Product.Application.Features.ServiceProviders.Post.Queries.GetCities;
using Product.Application.Features.ServiceProviders.Taroff.Queries.GetCities;

namespace Product.Application.Features.Common.Queries.GetCities
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
            if (request.CourierCode == (int)CourierCode.Post)
            {
                return await PostCities(request);
            }
            if (request.CourierCode == (int)CourierCode.Chapar)
            {
                return await ChaparCities(request);
            }
            if (request.CourierCode == (int)CourierCode.Taroff)
            {
                return await TaroffCities(request);
            }
            return new List<CourierCityDto>();
        }

        private async Task<List<CourierCityDto>?> PostCities(GetCourierCitiesQuery request)
        {
            var postResponse = await _mediator.Send(new GetPostCitiesQuery()
            {
                ProvinceId = request.StateId
            });
            if (postResponse.IsSuccess)
            {
                return _mapper.Map<List<CourierCityDto>>(postResponse.Data);
            }

            return null;
        }

        private async Task<List<CourierCityDto>?> ChaparCities(GetCourierCitiesQuery request)
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

            return null;
        }

        private async Task<List<CourierCityDto>?> TaroffCities(GetCourierCitiesQuery request)
        {
            var postResponse = await _mediator.Send(new GetTaroffCitiesQuery()
            {
                ProvinceId = request.StateId
            });
            if (postResponse.IsSuccess)
            {
                return _mapper.Map<List<CourierCityDto>>(postResponse.Data);
            }

            return null;
        }
    }
}