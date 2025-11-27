using MazyPlatform.SharedKernel.Domain.Results.Errors;

namespace MazyPlatform.SharedKernel.Domain.Results.Extensions;


public static class ResultMatchExtensions
{
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        return result.IsSuccess
                ? onSuccess()
                : onFailure(result.Errors);
    }

    public static T Match<T, TValue>(this Result<TValue> result, Func<TValue, T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        return result.IsSuccess
                ? onSuccess(result.Value)
                : onFailure(result.Errors);
    }

    public static async Task<T> MatchAsync<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess
            ? onSuccess()
            : onFailure(result.Errors);
    }

    public static async Task<T> MatchAsync<T, TValue>(this Task<Result<TValue>> resultTask, Func<TValue, T> onSuccess, Func<ErrorCollection, T> onFailure)
    {
        var result = await resultTask.ConfigureAwait(false);
        return result.IsSuccess
            ? onSuccess(result.Value)
            : onFailure(result.Errors);
    }
}