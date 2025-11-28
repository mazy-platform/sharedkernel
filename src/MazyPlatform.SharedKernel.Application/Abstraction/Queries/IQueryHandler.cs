using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Queries;

/// <summary>
/// Обработчик запроса (CQS), возвращающего ответ типа <typeparamref name="TResponse"/>.
/// Обработчики реализуют логику получения данных и не должны изменять состояние приложения.
/// </summary>
/// <typeparam name="TQuery">Тип запроса. Должен реализовывать <see cref="IQuery{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">Тип возвращаемого ответа. Не допускается <c>null</c>.</typeparam>
public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse> where TResponse : notnull
{
    /// <summary>
    /// Обработать запрос асинхронно и вернуть результат.
    /// </summary>
    /// <param name="query">Запрос для обработки. Не должен быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result{TResponse}"/>, 
    /// содержащий значение при успешном выполнении или набор ошибок при неудаче.
    /// </returns>
    Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}