using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Queries;

/// <summary>
/// Диспетчер запросов: отвечает за передачу запросов соответствующим обработчикам и возврат результата выполнения.
/// Запросы предназначены для чтения данных и не должны изменять состояние приложения.
/// </summary>
public interface IQueryDispatcher
{
    /// <summary>
    /// Отправляет запрос на обработку и возвращает результат с ответом типа <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">Тип возвращаемого ответа. Не допускается <c>null</c>.</typeparam>
    /// <param name="query">Запрос для выполнения. Не должен быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result{TResponse}"/>,
    /// содержащий значение при успешном выполнении или набор ошибок при неудаче.
    /// </returns>
    Task<Result<TResponse>> DispatchAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default) where TResponse : notnull;
}