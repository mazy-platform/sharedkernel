using MazyPlatform.SharedKernel.Domain.Abstraction;
using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Events;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task<Result> HandleAsync(TEvent domainEvent, CancellationToken cancellationToken = default);
}