using AutoMapper;
using Postex.UserManagement.Application.Dtos.Customers;
using Postex.UserManagement.Application.Features.CustomerCods.Commands.Create;
using Postex.UserManagement.Application.Features.CustomerCods.Commands.Update;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Create;
using Postex.UserManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;
using Postex.UserManagement.Application.Features.Customers.Commands.Create;
using Postex.UserManagement.Application.Features.Customers.Commands.Update;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<CreateCustomerCodCommand, CustomerCod>();
            CreateMap<UpdateCustomerCodCommand, CustomerCod>();
            CreateMap<CustomerCod, CustomerCodDto>();

            CreateMap<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>();
            CreateMap<UpdateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>();
            CreateMap<CustomerInvoiceInfo, CustomerInvoiceInfoDto>();
        }
    }
}
