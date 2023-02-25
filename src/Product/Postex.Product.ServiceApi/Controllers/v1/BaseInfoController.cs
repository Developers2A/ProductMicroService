﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Postex.Product.Application.Dtos.Commons;
using Postex.Product.Application.Dtos.Couriers;
using Postex.Product.Application.Dtos.CourierStatus;
using Postex.Product.Application.Features.BoxPrices.Queries;
using Postex.Product.Application.Features.Cities.Queries.GetCitiesCommon;
using Postex.Product.Application.Features.Couriers.Queries;
using Postex.Product.Application.Features.CourierServices.Queries;
using Postex.Product.Application.Features.CourierStatusMappings.Queries;
using Postex.Product.Application.Features.PostShops.Commands.SyncPostShops;
using Postex.Product.Application.Features.States.Queries;
using Postex.Product.ServiceApi.Filters;
using Postex.SharedKernel.Api;
using Postex.SharedKernel.Common.Enums;

namespace Postex.Product.ServiceApi.Controllers.v1
{
    [ApiVersion("1")]
    [ApiKey]
    public class BaseInfoController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public BaseInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("couriers")]
        public async Task<ApiResult<List<CourierCommonDto>>> GetCouriers()
        {
            return await _mediator.Send(new GetCouriersCommonQuery() { });
        }

        [HttpGet("courier-services")]
        public async Task<ApiResult<List<CourierServiceCommonDto>>> GetCourierServices()
        {
            return await _mediator.Send(new GetCourierServicesCommonQuery() { });
        }

        [HttpGet("states")]
        public async Task<ApiResult<List<StateCommonDto>>> GetStates()
        {
            return await _mediator.Send(new GetStatesCommonQuery());
        }

        [HttpPost("cities")]
        public async Task<ApiResult<List<CityCommonDto>>> GetCities(GetCitiesCommonQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("box-sizes")]
        public async Task<ApiResult<List<BoxSizeDto>>> GetBoxSizes()
        {
            return await _mediator.Send(new GetBoxSizesQuery());
        }

        [HttpGet("status-mappings/{courierCode}")]
        public async Task<ApiResult<List<CourierStatusMappingDetailsDto>>> GetStatusMappings(int courierCode = 0)
        {
            return await _mediator.Send(new GetCourierStatusMappingsQuery()
            {
                CourierCode = (CourierCode)courierCode
            });
        }

        [HttpGet("sync-shops")]
        public async Task SyncShops()
        {
            await _mediator.Send(new SyncPostShopsCommand()
            {
                FromDate = DateTime.Now.AddYears(-15),
                ToDate = DateTime.Now.AddYears(15)
            });
        }
    }
}