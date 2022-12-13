using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.SLAs.Queries.GetSLAs
{
    public class GetSLAsQuery : IRequest<List<SLADto>>
    {
    }
}
