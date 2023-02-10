﻿using AutoMapper;
using Postex.ProfileManagement.Application.Dtos;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerCods.Commands.Update;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Create;
using Postex.ProfileManagement.Application.Features.CustomerInvoiceInfos.Commands.Update;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Create;
using Postex.ProfileManagement.Application.Features.Customers.Commands.Update;
using Postex.ProfileManagement.Domain;

namespace Postex.ProfileManagement.Application.Mapping
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

            CreateMap<CustomerCod, CustomerDto>();

            CreateMap<CreateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>();
            CreateMap<UpdateCustomerInvoiceInfoCommand, CustomerInvoiceInfo>();

            CreateMap<CustomerInvoiceInfo, CustomerInvoiceInfoDto>();
        }
    }
}
