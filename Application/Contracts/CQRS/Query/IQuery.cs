using FluentResults;
using MediatR;

namespace Application.Abstractions.CQRS.Query
{
    public interface IQuery<TResponse>: IRequest<Result<TResponse>>
    {
    }
}
