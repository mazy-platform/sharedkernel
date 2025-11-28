using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Commands;

public interface ICommandDispatcher
{
    Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken = default);

    Task<Result<TResponse>> DispatchAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default) where TResponse : notnull;
}