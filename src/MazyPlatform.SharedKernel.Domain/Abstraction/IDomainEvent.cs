namespace MazyPlatform.SharedKernel.Domain.Abstraction;

/// <summary>
/// Представляет доменное событие с уникальным идентификатором и временем возникновения.
/// Доменные события используются для уведомления о произошедших изменениях в доменной модели.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Уникальный идентификатор события.
    /// </summary>
    /// <value>Значение типа <see cref="Guid"/> — уникальный идентификатор события.</value>
    Guid EventId { get; }

    /// <summary>
    /// Временная метка возникновения события.
    /// </summary>
    /// <value>Значение типа <see cref="DateTimeOffset"/> — время возникновения события.</value>
    DateTimeOffset OccurredAt { get; }
}