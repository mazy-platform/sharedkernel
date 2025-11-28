using MazyPlatform.SharedKernel.Domain.Abstraction;
using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Events;

public interface IDomainEventsDispatcher
{
    Task<Result> DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}