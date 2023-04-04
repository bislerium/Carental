using FluentResults;
using MediatR;

namespace Carental.Application.Abstractions.CQRS.Command
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}

