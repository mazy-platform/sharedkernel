using MazyPlatform.SharedKernel.Domain.Abstraction;
using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Events;

/// <summary>
/// Диспетчер доменных событий: отвечает за распространение набора доменных событий
/// соответствующим обработчикам и за координацию их асинхронной обработки.
/// </summary>
public interface IDomainEventsDispatcher
{
    /// <summary>
    /// Отправляет коллекцию доменных событий на обработку.
    /// </summary>
    /// <param name="domainEvents">Коллекция доменных событий для обработки. Не должна быть <c>null</c> и может содержать ноль или более событий.</param>
    /// <param name="cancellationToken">Токен отмены для операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result"/>,
    /// содержащий успешный статус или набор ошибок при неудаче обработки одного или нескольких событий.
    /// </returns>
    Task<Result> DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}