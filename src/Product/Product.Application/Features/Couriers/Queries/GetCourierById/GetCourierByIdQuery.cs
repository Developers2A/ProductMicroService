using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.Couriers.Queries.GetCourierById
{
    public class GetCourierByIdQuery : IRequest<CourierDto>
    {
        public int Id { get; set; }
    }
}
