using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.Couriers.Queries.GetCouriers
{
    public class GetCouriersQuery : IRequest<List<CourierDto>>
    {
    }
}
