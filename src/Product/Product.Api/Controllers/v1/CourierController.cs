﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Postex.SharedKernel.Api;
using Product.Application.Dtos.Couriers;
using Product.Application.Features.Couriers.Commands.CreateCourier;
using Product.Application.Features.Couriers.Commands.UpdateCourier;
using Product.Application.Features.Couriers.Queries.GetCourierById;
using Product.Application.Features.CourierServices.Queries;

namespace Product.Api.Controllers.v1
{
    [ApiVersion("1")]
    [AllowAnonymous]
    public class CourierController : BaseApiControllerWithDefaultRoute
    {
        private readonly IMediator _mediator;

        public CourierController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ApiResult> Post([FromBody] CreateCourierCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ApiResult> Put([FromBody] UpdateCourierCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<ApiResult<List<CourierDto>>> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCourierServicesQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CourierDto>> Get([FromRoute] int id, CancellationToken cancellationToken = default)
        {
            var query = new GetCourierByIdQuery() { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
