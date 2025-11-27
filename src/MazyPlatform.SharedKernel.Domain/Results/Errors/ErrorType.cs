namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

/// <summary>
/// Тип ошибки, используемый в результатах операций внутри доменной логики.
/// </summary>
public enum ErrorType
{
    /// <summary>
    /// Ошибка валидации входных данных или бизнес-правил.
    /// </summary>
    Validation,

    /// <summary>
    /// Запрошенный ресурс не найден.
    /// </summary>
    NotFound,

    /// <summary>
    /// Отсутствуют права доступа или не пройдена аутентификация.
    /// </summary>
    Unauthorized,

    /// <summary>
    /// Конфликт состояния (например, нарушение уникальности или конкурентное изменение).
    /// </summary>
    Conflict,

    /// <summary>
    /// Внутренняя ошибка приложения или сервисов.
    /// </summary>
    Internal,

    /// <summary>
    /// Непредвиденное исключение, не попавшее в другие категории.
    /// </summary>
    Exception
}