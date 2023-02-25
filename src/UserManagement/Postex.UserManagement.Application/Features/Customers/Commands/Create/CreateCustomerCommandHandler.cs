﻿using AutoMapper;
using MediatR;
using Postex.SharedKernel.Interfaces;
using Postex.UserManagement.Domain.Customers;

namespace Postex.UserManagement.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IWriteRepository<Customer> _writeRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IWriteRepository<Customer> writeRepository, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        async Task<Customer> IRequestHandler<CreateCustomerCommand, Customer>.Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);
            await _writeRepository.AddAsync(customer, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            // var customerDto = _mapper.Map<CustomerDto>(customer);
            return customer;
        }
    }
}