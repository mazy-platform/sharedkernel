namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

public enum ErrorType
{
    Validation,
    NotFound,
    Unauthorized,
    Conflict,
    Internal,
    Exception
}