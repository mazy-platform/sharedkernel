using MazyPlatform.SharedKernel.Domain.Results;

namespace MazyPlatform.SharedKernel.Application.Abstraction.Commands;

/// <summary>
/// Обработчик команды без возвращаемого значения.
/// Предназначен для обработки команд, изменяющих состояние приложения и не возвращающих результат.
/// </summary>
/// <typeparam name="TCommand">Тип команды. Должен реализовывать <see cref="ICommand"/>.</typeparam>
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    /// <summary>
    /// Обработать команду асинхронно.
    /// </summary>
    /// <param name="command">Команда для обработки. Не должна быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result"/>,
    /// содержащий статус выполнения или набор ошибок при неудаче.
    /// </returns>
    Task<Result> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

/// <summary>
/// Обработчик команды с возвращаемым значением.
/// Предназначен для обработки команд, которые при успешном выполнении возвращают значение типа <typeparamref name="TResponse"/>.
/// </summary>
/// <typeparam name="TCommand">Тип команды. Должен реализовывать <see cref="ICommand{TResponse}"/>.</typeparam>
/// <typeparam name="TResponse">Тип возвращаемого ответа. Не допускается <c>null</c>.</typeparam>
public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse> where TResponse : notnull
{
    /// <summary>
    /// Обработать команду асинхронно и получить результат.
    /// </summary>
    /// <param name="command">Команда для обработки. Не должна быть <c>null</c>.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>
    /// Задача, представляющая асинхронную операцию. Результат — <see cref="Result{TResponse}"/>,
    /// содержащий значение при успешном выполнении или набор ошибок при неудаче.
    /// </returns>
    Task<Result<TResponse>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}