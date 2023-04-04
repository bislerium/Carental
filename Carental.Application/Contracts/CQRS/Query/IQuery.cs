using FluentResults;
using MediatR;

namespace Carental.Application.Abstractions.CQRS.Query
{
    public interface IQuery<TResponse>: IRequest<Result<TResponse>>
    {
    }
}
