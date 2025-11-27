using MazyPlatform.SharedKernel.Domain.Results.Errors;

namespace MazyPlatform.SharedKernel.Domain.Results;

public sealed record class Result<T> : Result
{
    public Result(T value) : base(ResultStatus.Success) => Value = value;
    public Result(ErrorCollection errors) : base(errors) { }


    public T Value
        => field is not null && IsSuccess
            ? field : throw new InvalidOperationException("Не удается получить доступ к значению неудачного результата.");


    public static Result<T> Success(T value) => new(value ?? throw new ArgumentNullException(nameof(value)));
    public static new Result<T> Failure(ErrorCollection errors) => new(errors ?? throw new ArgumentNullException(nameof(errors)));


    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);
    public static implicit operator Result<T>(ErrorCollection errors) => Failure(errors);
}