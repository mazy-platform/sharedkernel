namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

public sealed record class Error
{
    private Error(string message, ErrorType type)
    {
        Message = message;
        Type = type;
    }


    public string Message { get; }
    public ErrorType Type { get; }
    public Exception? Ex { get; init; }


    public static Error Validation(string message = "Ошибки валидации.")
        => new(message, ErrorType.Validation);

    public static Error NotFound(string message = "Ресурс не найден.")
        => new(message, ErrorType.NotFound);

    public static Error Unauthorized(string message = "Доступ запрещен.")
        => new(message, ErrorType.Unauthorized);

    public static Error Conflict(string message = "Конфликт данных.")
        => new(message, ErrorType.Conflict);

    public static Error Internal(string message = "Внутренняя ошибка сервера.")
        => new(message, ErrorType.Internal);

   
    public static Error Exception(Exception exception, string message = "Произошло исключение.")
        => new(message, ErrorType.Exception) { Ex = exception };
}