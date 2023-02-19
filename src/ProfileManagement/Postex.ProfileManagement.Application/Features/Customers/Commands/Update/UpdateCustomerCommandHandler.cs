using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Postex.ProfileManagement.Domain;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.ProfileManagement.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IWriteRepository<Customer> _writeRepository;
        private readonly IReadRepository<Customer> _readRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IWriteRepository<Customer> writeRepository, IReadRepository<Customer> readRepository, IMapper mapper)
        {
            this._writeRepository = writeRepository;
            this._readRepository = readRepository;
            this._mapper = mapper;
        }

        async Task<Customer> IRequestHandler<UpdateCustomerCommand, Customer>.Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer =  await _readRepository.Table
                .Where(c=> c.Id == request.Id).FirstOrDefaultAsync();

            if (customer == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            // customer = _mapper.Map<Customer>(request);
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.FatherName = request.FatherName;
            customer.Email = request.Email;
            customer.MobileNo = request.MobileNo;
            customer.NationalCode = request.NationalCode;
            customer.PostalCode = request.PostalCode;
            customer.UserId = request.UserId;
            customer.IsActive = request.IsActive;
            customer.isShahkarValidate = request.IsShahkarValidate;

            await _writeRepository.UpdateAsync(customer, cancellationToken);
            await _writeRepository.SaveChangeAsync(cancellationToken);
            return customer;
        }
    }
}
