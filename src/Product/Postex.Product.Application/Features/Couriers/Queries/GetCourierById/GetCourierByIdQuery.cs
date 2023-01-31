using MediatR;
using Postex.Product.Application.Dtos.Couriers;

namespace Postex.Product.Application.Features.Couriers.Queries.GetCourierById
{
    public class GetCourierByIdQuery : IRequest<CourierDto>
    {
        public int Id { get; set; }
    }
}
