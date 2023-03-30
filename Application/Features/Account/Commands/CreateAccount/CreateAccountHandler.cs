﻿using Application.Abstractions.CQRS.Command;
using Domain.UnitOfWork;
using FluentResults;

namespace Application.Features.Account.Commands.CreateAccount
{
    public sealed class CreateAccountHandler : ICommandHandler<CreateAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Result> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}