using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierServices.Queries.GetCourierServiceById
{
    public class GetCourierServiceByIdQuery : IRequest<CourierServiceDto>
    {
        public int Id { get; set; }
    }
}
