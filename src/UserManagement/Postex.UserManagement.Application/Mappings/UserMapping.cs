using AutoMapper;
using Postex.UserManagement.Application.Dtos.Users;
using Postex.UserManagement.Application.Features.UserCods.Commands.Create;
using Postex.UserManagement.Application.Features.UserCods.Commands.Update;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Create;
using Postex.UserManagement.Application.Features.UserInvoiceInfos.Commands.Update;
using Postex.UserManagement.Application.Features.Users.Commands.Create;
using Postex.UserManagement.Application.Features.Users.Commands.Update;
using Postex.UserManagement.Domain.Users;

namespace Postex.UserManagement.Application.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();

            CreateMap<CreateUserCodCommand, UserCod>();
            CreateMap<UpdateUserCodCommand, UserCod>();
            CreateMap<UserCod, UserCodDto>();

            CreateMap<CreateUserInvoiceInfoCommand, UserInvoiceInfo>();
            CreateMap<UpdateUserInvoiceInfoCommand, UserInvoiceInfo>();
            CreateMap<UserInvoiceInfo, UserInvoiceInfoDto>();
        }
    }
}
