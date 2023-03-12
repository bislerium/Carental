using FluentResults;
using MediatR;

namespace Application.Abstractions.CQRS.Command
{
    public interface ICommand : IRequest<Result>
    {
    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}

