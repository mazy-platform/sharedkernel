using MazyPlatform.SharedKernel.Domain.Results.Errors;

namespace MazyPlatform.SharedKernel.Domain.Results;

/// <summary>
/// Представляет результат операции, содержащий значение типа <typeparamref name="T"/> в случае успеха
/// или коллекцию ошибок в случае неудачи.
/// </summary>
/// <typeparam name="T">Тип возвращаемого значения при успешном результате.</typeparam>
public sealed record class Result<T> : Result
{
    /// <summary>
    /// Создаёт успешный результат с указанным значением.
    /// </summary>
    /// <param name="value">Значение успешного результата.</param>
    public Result(T value) : base(ResultStatus.Success) => Value = value;

    /// <summary>
    /// Создаёт неудачный результат с заданной коллекцией ошибок.
    /// </summary>
    /// <param name="errors">Коллекция ошибок.</param>
    public Result(ErrorCollection errors) : base(errors) { }

    /// <summary>
    /// Значение успешного результата.
    /// </summary>
    /// <exception cref="InvalidOperationException">Выбрасывается, если попытаться получить значение у неудачного результата.</exception>
    public T Value
        => field is not null && IsSuccess
            ? field : throw new InvalidOperationException("Не удается получить доступ к значению неудачного результата.");

    /// <summary>
    /// Создать успешный результат с указанным значением.
    /// </summary>
    /// <param name="value">Значение.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/>, представляющий успешный результат с указанным значением.</returns>
    public static Result<T> Success(T value) => new(value ?? throw new ArgumentNullException(nameof(value)));

    /// <summary>
    /// Создать неудачный результат с указанной коллекцией ошибок.
    /// </summary>
    /// <param name="errors">Коллекция ошибок.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/>, представляющий неудачу с указанными ошибками.</returns>
    public static new Result<T> Failure(ErrorCollection errors) => new(errors ?? throw new ArgumentNullException(nameof(errors)));

    /// <summary>
    /// Неявное преобразование результата в значение. Приведение извлекает <see cref="Value"/>.
    /// </summary>
    /// <param name="result">Результат.</param>
    /// <returns>Значение <typeparamref name="T"/>, содержащееся в успешном результате.</returns>
    public static implicit operator T(Result<T> result) => result.Value;

    /// <summary>
    /// Неявное создание успешного результата из значения.
    /// </summary>
    /// <param name="value">Значение.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/>, представляющий успешный результат с указанным значением.</returns>
    public static implicit operator Result<T>(T value) => Success(value);

    /// <summary>
    /// Неявное преобразование одиночной ошибки в неудачный результат типа <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="error">Ошибка.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/>, представляющий неудачу с одной ошибкой.</returns>
    public static implicit operator Result<T>(Error error) => Failure(error);

    /// <summary>
    /// Неявное преобразование коллекции ошибок в неудачный результат типа <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="errors">Коллекция ошибок.</param>
    /// <returns>Экземпляр <see cref="Result{T}"/>, представляющий неудачу с указанными ошибками.</returns>
    public static implicit operator Result<T>(ErrorCollection errors) => Failure(errors);
}