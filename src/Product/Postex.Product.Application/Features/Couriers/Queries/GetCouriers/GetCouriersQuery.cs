using MediatR;
using Postex.Product.Application.Dtos.Couriers;

namespace Postex.Product.Application.Features.Couriers.Queries.GetCouriers
{
    public class GetCouriersQuery : IRequest<List<CourierDto>>
    {
    }
}
