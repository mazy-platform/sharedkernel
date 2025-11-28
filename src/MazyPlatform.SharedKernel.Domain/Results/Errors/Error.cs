namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

/// <summary>
/// Представляет ошибку операции с типом, сообщением и необязательной исключительной информацией.
/// Используется в результате операций для передачи информации об ошибке без бросания исключений.
/// </summary>
public sealed record class Error
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="Error"/> с указанным сообщением и типом ошибки.
    /// Конструктор скрыт — экземпляры создаются через статические фабрики.
    /// </summary>
    /// <param name="message">Краткое сообщение об ошибке.</param>
    /// <param name="type">Тип ошибки.</param>
    private Error(string message, ErrorType type)
    {
        Message = message;
        Type = type;
    }

    /// <summary>
    /// Читабельное сообщение, описывающее суть ошибки (для отображения или логирования).
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Категория ошибки, определяющая тип проблемы (валидация, не найдено, конфликт и т.д.).
    /// </summary>
    public ErrorType Type { get; }

    /// <summary>
    /// Необязательное исключение, связанное с ошибкой — может содержать стек вызовов и дополнительную информацию.
    /// Устанавливается только для фабрики <see cref="Exception(Exception, string)"/>.
    /// </summary>
    public Exception? Ex { get; init; }


    /// <summary>
    /// Создаёт ошибку типа валидации с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке валидации. По умолчанию "Ошибки валидации."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.Validation"/>.</returns>
    public static Error Validation(string message = "Ошибки валидации.")
        => new(message, ErrorType.Validation);

    /// <summary>
    /// Создаёт ошибку типа "не найдено" с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение. По умолчанию "Ресурс не найден."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.NotFound"/>.</returns>
    public static Error NotFound(string message = "Ресурс не найден.")
        => new(message, ErrorType.NotFound);

    /// <summary>
    /// Создаёт ошибку доступа (unauthorized) с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение. По умолчанию "Доступ запрещен."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.Unauthorized"/>.</returns>
    public static Error Unauthorized(string message = "Доступ запрещен.")
        => new(message, ErrorType.Unauthorized);

    /// <summary>
    /// Создаёт ошибку конфликта данных с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение. По умолчанию "Конфликт данных."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.Conflict"/>.</returns>
    public static Error Conflict(string message = "Конфликт данных.")
        => new(message, ErrorType.Conflict);

    /// <summary>
    /// Создаёт ошибку внутреннего сервера с указанным сообщением.
    /// </summary>
    /// <param name="message">Сообщение. По умолчанию "Внутренняя ошибка сервера."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.Internal"/>.</returns>
    public static Error Internal(string message = "Внутренняя ошибка сервера.")
        => new(message, ErrorType.Internal);

    /// <summary>
    /// Создаёт ошибку представляющую исключение. Связывает исходное <paramref name="exception"/> с объектом ошибки.
    /// </summary>
    /// <param name="exception">Исходное исключение, которое привело к ошибке.</param>
    /// <param name="message">Сообщение для отображения/логирования. По умолчанию "Произошло исключение."</param>
    /// <returns>Экземпляр <see cref="Error"/> с <see cref="ErrorType.Exception"/> и установленным свойством <see cref="Ex"/>.</returns>
    public static Error Exception(Exception exception, string message = "Произошло исключение.")
        => new(message, ErrorType.Exception) { Ex = exception };
}