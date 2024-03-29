﻿using FluentValidation;
using MediatR;

namespace Carental.Application.Behaviours
{
    internal class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var validationFailures = validationResults.SelectMany(r => r.Errors).Where(f => f is not null).ToList();

                if (validationFailures.Count != 0)
                {
                    throw new ValidationException(validationFailures);
                }
            }
            return await next();
        }
    }
}
