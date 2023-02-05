﻿using FluentValidation;
using MediatR;

namespace Postex.UserManagement.Application.Behaviours
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
                return next();

            var context = new ValidationContext<TRequest>(request);
            var errors = _validators
                .Select(x => x.Validate(context))
                .Where(t => t.Errors is not null)
                .SelectMany(t => t.Errors)
                .DistinctBy(t => t.ErrorMessage)
                .ToList();

            if (errors.Any())
            {
                var faErrors = errors.GroupBy(x => x.PropertyName).Select(g => g.LastOrDefault());
                throw new ValidationException(faErrors);
            }

            return next();
        }
    }
}
