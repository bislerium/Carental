using FluentResults;
using MediatR;

namespace Carental.Application.Abstractions.CQRS.Query
{
    public interface IQueryHandler<TQuery, TResponse>: IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
