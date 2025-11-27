using MazyPlatform.SharedKernel.Domain.Results.Errors;
using System.Diagnostics.CodeAnalysis;

namespace MazyPlatform.SharedKernel.Domain.Results;

public record class Result
{
    private readonly ResultStatus _status;

    protected Result(ResultStatus status) => _status = status;
    protected Result(ErrorCollection error) : this(ResultStatus.Failure) => Errors = error;

    [MemberNotNullWhen(false, nameof(Errors))]
    public bool IsSuccess => _status is ResultStatus.Success;
    [MemberNotNullWhen(true, nameof(Errors))]
    public bool IsFailure => _status is ResultStatus.Failure;

    public ErrorCollection? Errors { get; init; }
    

    public static Result Success() => new(ResultStatus.Success);
    public static Result Failure(ErrorCollection errors) => new(errors ?? throw new ArgumentNullException(nameof(errors)));

    
    public static implicit operator Result(Error error) => Failure(error);
    public static implicit operator Result(ErrorCollection errors) => Failure(errors);


    protected enum ResultStatus
    {
        Success,
        Failure
    }
}