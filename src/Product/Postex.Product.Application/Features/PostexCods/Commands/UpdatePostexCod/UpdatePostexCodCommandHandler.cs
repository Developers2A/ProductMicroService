﻿using MediatR;
using Postex.Product.Domain.ValueAddedPrices;
using Postex.SharedKernel.Exceptions;
using Postex.SharedKernel.Interfaces;

namespace Postex.Product.Application.Features.PostexCods.Commands.UpdatePostexCod
{
    public class UpdatePostexCodCommandHandler : IRequestHandler<UpdatePostexCodCommand>
    {
        private readonly IWriteRepository<PostexCod> _writeRepository;
        private readonly IReadRepository<PostexCod> _readRepository;

        public UpdatePostexCodCommandHandler(IWriteRepository<PostexCod> writeRepository,
            IReadRepository<PostexCod> readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<Unit> Handle(UpdatePostexCodCommand request, CancellationToken cancellationToken)
        {
            PostexCod postexCod = await _readRepository.GetByIdAsync(request.Id, cancellationToken);

            if (postexCod == null)
                throw new AppException("اطلاعات مورد نظر یافت نشد");

            await _writeRepository.UpdateAsync(postexCod);
            await _writeRepository.SaveChangeAsync();

            return Unit.Value;
        }
    }
}