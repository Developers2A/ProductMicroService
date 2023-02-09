using MediatR;
using Postex.ProfileManagement.Application.Dtos;

namespace Postex.ProfileManagement.Application.Features.CustomerCods.Queries
{
    public class GetByIdQuery:IRequest<CustomerCodDto>
    {
        public int Id { get; set; }
    }
}
