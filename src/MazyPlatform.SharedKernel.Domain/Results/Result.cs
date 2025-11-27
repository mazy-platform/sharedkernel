using MazyPlatform.SharedKernel.Domain.Results.Errors;
using System.Diagnostics.CodeAnalysis;

namespace MazyPlatform.SharedKernel.Domain.Results;

/// <summary>
/// Представляет результат выполнения операции: успех или неудача с коллекцией ошибок.
/// </summary>
public record class Result
{
    private readonly ResultStatus _status;

    /// <summary>
    /// Создаёт экземпляр результата с указанным статусом.
    /// </summary>
    /// <param name="status">Статус результата.</param>
    protected Result(ResultStatus status) => _status = status;

    /// <summary>
    /// Создаёт результат неудачи с набором ошибок.
    /// </summary>
    /// <param name="error">Коллекция ошибок.</param>
    protected Result(ErrorCollection error) : this(ResultStatus.Failure) => Errors = error;

    /// <summary>
    /// Возвращает true, если результат — успех. Когда <see cref="IsSuccess"/> равно false, свойство <see cref="Errors"/> гарантированно не равно null.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Errors))]
    public bool IsSuccess => _status is ResultStatus.Success;

    /// <summary>
    /// Возвращает true, если результат — неудача. Когда <see cref="IsFailure"/> равно true, свойство <see cref="Errors"/> гарантированно не равно null.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Errors))]
    public bool IsFailure => _status is ResultStatus.Failure;

    /// <summary>
    /// Коллекция ошибок для неудачного результата. Имеет значение null для успешного результата.
    /// </summary>
    public ErrorCollection? Errors { get; init; }

    /// <summary>
    /// Создать успешный результат.
    /// </summary>
    /// <returns>Экземпляр <see cref="Result"/>, представляющий успешный результат.</returns>
    public static Result Success() => new(ResultStatus.Success);

    /// <summary>
    /// Создать результат с ошибками. Параметр <paramref name="errors"/> не может быть null.
    /// </summary>
    /// <param name="errors">Коллекция ошибок.</param>
    /// <returns>Экземпляр <see cref="Result"/>, представляющий неудачу.</returns>
    public static Result Failure(ErrorCollection errors) => new(errors ?? throw new ArgumentNullException(nameof(errors)));

    /// <summary>
    /// Неявное преобразование одиночной ошибки в результат неудачи.
    /// </summary>
    /// <param name="error">Ошибка.</param>
    /// <returns>Экземпляр <see cref="Result"/>, представляющий неудачу с одной ошибкой.</returns>
    public static implicit operator Result(Error error) => Failure(error);

    /// <summary>
    /// Неявное преобразование коллекции ошибок в результат неудачи.
    /// </summary>
    /// <param name="errors">Коллекция ошибок.</param>
    /// <returns>Экземпляр <see cref="Result"/>, представляющий неудачу с указанными ошибками.</returns>
    public static implicit operator Result(ErrorCollection errors) => Failure(errors);

    /// <summary>
    /// Внутреннее представление статуса результата.
    /// </summary>
    protected enum ResultStatus
    {
        /// <summary>
        /// Операция выполнена успешно.
        /// </summary>
        Success,

        /// <summary>
        /// Операция завершилась с ошибкой.
        /// </summary>
        Failure
    }
}