using MediatR;
using Product.Application.Dtos.Couriers;

namespace Product.Application.Features.SLAs.Queries.GetSLAById
{
    public class GetSLAByIdQuery : IRequest<SLADto>
    {
        public int Id { get; set; }
    }
}
