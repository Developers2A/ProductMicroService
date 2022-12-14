using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.CourierServices.Queries.GetCourierServices
{
    public class GetCourierServicesQuery : IRequest<List<CourierServiceDto>>
    {
    }
}
