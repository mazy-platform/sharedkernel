using MazyPlatform.SharedKernel.Domain.Abstraction;
using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Events;

/// <summary>
/// Обработчик доменного события.
/// Обработчики получают доменные события и выполняют сопутствующую логику (проекции, интеграции, побочные эффекты и т.п.).
/// </summary>
/// <typeparam name="TEvent">Тип доменного события. Должен реализовывать <see cref="IDomainEvent"/>.</typeparam>
public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    /// <summary>
    /// Обработать доменное событие асинхронно.
    /// </summary>
    /// <param name="domainEvent">Экземпляр доменного события для обработки. Не должен быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result"/>,
    /// содержащий успешный статус или набор ошибок при неудаче.
    /// </returns>
    Task<Result> HandleAsync(TEvent domainEvent, CancellationToken cancellationToken = default);
}