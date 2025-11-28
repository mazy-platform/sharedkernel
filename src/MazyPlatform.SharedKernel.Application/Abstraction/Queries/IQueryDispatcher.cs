using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Queries;

public interface IQueryDispatcher
{
    Task<Result<TResponse>> DispatchAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default) where TResponse : notnull;
}