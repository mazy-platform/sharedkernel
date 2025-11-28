namespace MazyPlatform.SharedKernel.Domain.Abstraction;

public interface IDomainEvent
{
    Guid EventId { get; }
    DateTimeOffset OccurredAt { get; }
}