using MazyPlatform.SharedKernel.Domain.Results.Errors;

namespace MazyPlatform.SharedKernel.Domain.Results.Extensions;

/// <summary>
/// Набор расширений для сопоставления результата с обработчиками успеха и неудачи (match pattern).
/// </summary>
public static class ResultMatchExtensions
{
    /// <summary>
    /// Выполняет сопоставление для не типизированного результата: вызывает <paramref name="onSuccess"/>, если результат успешен,
    /// иначе вызывает <paramref name="onFailure"/> с коллекцией ошибок.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения обработчиков.</typeparam>
    /// <param name="result">Результат операции.</param>
    /// <param name="onSuccess">Функция, вызываемая при успешном результате.</param>
    /// <param name="onFailure">Функция, вызываемая при неудачном результате, получает <see cref="ErrorCollection"/>.</param>
    /// <returns>Значение типа <typeparamref name="T"/>, возвращённое соответствующим обработчиком.</returns>
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Errors);
    }

    /// <summary>
    /// Выполняет сопоставление для generic результата: вызывает <paramref name="onSuccess"/> с <see cref="Result{TValue}.Value"/>, если результат успешен,
    /// иначе вызывает <paramref name="onFailure"/> с коллекцией ошибок.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения обработчиков.</typeparam>
    /// <typeparam name="TValue">Тип значения внутри успешного результата.</typeparam>
    /// <param name="result">Результат операции содержащий значение типа <typeparamref name="TValue"/>.</param>
    /// <param name="onSuccess">Функция, вызываемая при успешном результате, получает значение <typeparamref name="TValue"/>.</param>
    /// <param name="onFailure">Функция, вызываемая при неудачном результате, получает <see cref="ErrorCollection"/>.</param>
    /// <returns>Значение типа <typeparamref name="T"/>, возвращённое соответствующим обработчиком.</returns>
    public static T Match<T, TValue>(this Result<TValue> result, Func<TValue, T> onSuccess, Func<ErrorCollection, T> onFailure) where TValue : notnull
    {
        return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Errors);
    }

    /// <summary>
    /// Асинхронная версия сопоставления для задачи с не типизированным результатом.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения обработчиков.</typeparam>
    /// <param name="resultTask">Задача, возвращающая <see cref="Result"/>.</param>
    /// <param name="onSuccess">Функция, вызываемая при успешном результате.</param>
    /// <param name="onFailure">Функция, вызываемая при неудачном результате, получает <see cref="ErrorCollection"/>.</param>
    /// <returns>Задача, возвращающая значение типа <typeparamref name="T"/>, полученное от соответствующего обработчика.</returns>
    public static async Task<T> MatchAsync<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Errors);
    }

    /// <summary>
    /// Асинхронная версия сопоставления для задачи с generic результатом.
    /// </summary>
    /// <typeparam name="T">Тип возвращаемого значения обработчиков.</typeparam>
    /// <typeparam name="TValue">Тип значения внутри успешного результата.</typeparam>
    /// <param name="resultTask">Задача, возвращающая <see cref="Result{TValue}"/>.</param>
    /// <param name="onSuccess">Функция, вызываемая при успешном результате, получает значение <typeparamref name="TValue"/>.</param>
    /// <param name="onFailure">Функция, вызываемая при неудачном результате, получает <see cref="ErrorCollection"/>.</param>
    /// <returns>Задача, возвращающая значение типа <typeparamref name="T"/>, полученное от соответствующего обработчика.</returns>
    public static async Task<T> MatchAsync<T, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, T> onSuccess, Func<ErrorCollection, T> onFailure) where TValue : notnull
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }
}