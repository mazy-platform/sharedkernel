using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Queries;

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : notnull
{
    Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}