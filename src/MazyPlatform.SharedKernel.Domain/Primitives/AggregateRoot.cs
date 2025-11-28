using MazyPlatform.SharedKernel.Domain.Abstraction;

namespace MazyPlatform.SharedKernel.Domain.Primitives;

/// <summary>
/// Базовый класс для корней агрегатов в доменной модели.
/// Предоставляет поддержку накопления доменных событий и методы управления ними.
/// </summary>
public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Коллекция доменных событий, накопленных агрегатом.
    /// </summary>
    /// <value>Коллекция <see cref="IDomainEvent"/>, доступная только для чтения.</value>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Очищает накопленные доменные события.
    /// </summary>
    protected void ClearDomainEvents() => _domainEvents.Clear();

    /// <summary>
    /// Добавляет доменное событие в коллекцию.
    /// </summary>
    /// <param name="domainEvent">Событие, которое необходимо добавить.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}