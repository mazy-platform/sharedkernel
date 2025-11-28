using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Commands;

/// <summary>
/// Диспетчер команд: отвечает за передачу команд соответствующим обработчикам и получение результата их выполнения.
/// Выполнение асинхронное; результаты оборачиваются в <see cref="Result"/> или <see cref="Result{TResponse}"/>.
/// </summary>
public interface ICommandDispatcher
{
    /// <summary>
    /// Отправляет команду без возвращаемого значения на обработку.
    /// </summary>
    /// <param name="command">Команда для выполнения. Не должна быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены для операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — экземпляр <see cref="Result"/>, 
    /// содержащий успешный статус или набор ошибок при неудаче.
    /// </returns>
    Task<Result> DispatchAsync(ICommand command, CancellationToken cancellationToken = default);

    /// <summary>
    /// Отправляет команду, возвращающую ответ типа <typeparamref name="TResponse"/>, на обработку.
    /// </summary>
    /// <typeparam name="TResponse">Тип возвращаемого ответа. Не допускается <c>null</c>.</typeparam>
    /// <param name="command">Команда для выполнения. Не должна быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены для операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — экземпляр <see cref="Result{TResponse}"/>, 
    /// содержащий значение при успешном выполнении или набор ошибок при неудаче.
    /// </returns>
    Task<Result<TResponse>> DispatchAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default) where TResponse : notnull;
}