using System.Collections;

namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

/// <summary>
/// Представляет неизменяемую коллекцию объектов <see cref="Error"/>.
/// </summary>
/// <remarks>
/// Реализует <see cref="IEnumerable{Error}"/>, чтобы обеспечить перебор содержащихся ошибок.
/// Коллекция материализуется в массив при создании для обеспечения стабильной итерации.
/// </remarks>
public sealed record class ErrorCollection : IEnumerable<Error>
{
    /// <summary>
    /// Внутреннее хранилище ошибок.
    /// </summary>
    /// <remarks>
    /// Материализуется в массив в конструкторе, чтобы предотвратить ленивую повторную итерацию
    /// исходного <see cref="IEnumerable{Error}"/> и обеспечить предсказуемое поведение при перечислении.
    /// </remarks>
    private readonly IEnumerable<Error> _errors;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ErrorCollection"/>, содержащий указанные ошибки.
    /// </summary>
    /// <param name="errors">Коллекция ошибок для включения в результат.</param>
    /// <exception cref="ArgumentNullException">Если <paramref name="errors"/> равен <c>null</c>.</exception>
    public ErrorCollection(IEnumerable<Error> errors) => _errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));


    /// <summary>
    /// Возвращает перечислитель, выполняющий перебор коллекции <see cref="Error"/>.
    /// </summary>
    /// <returns>Экземпляр <see cref="IEnumerator{Error}"/> для перебора ошибок.</returns>
    public IEnumerator<Error> GetEnumerator() => _errors.GetEnumerator();
    /// <summary>
    /// Возвращает неуниверсальный перечислитель, выполняющий перебор коллекции <see cref="Error"/>.
    /// </summary>
    /// <returns>Экземпляр <see cref="IEnumerator"/> для перебора ошибок.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    /// <summary>
    /// Неявное преобразование одиночной ошибки в коллекцию.
    /// </summary>
    /// <param name="error">Ошибка.</param>
    /// <returns>Экземпляр <see cref="ErrorCollection"/>, содержащий указанную ошибку.</returns>
    public static implicit operator ErrorCollection(Error error) => new([error]);

    /// <summary>
    /// Неявное преобразование массива ошибок в коллекцию.
    /// </summary>
    /// <param name="errors">Массив ошибок.</param>
    /// <returns>Экземпляр <see cref="ErrorCollection"/>, содержащий указанные ошибки.</returns>
    public static implicit operator ErrorCollection(Error[] errors) => new(errors);
}