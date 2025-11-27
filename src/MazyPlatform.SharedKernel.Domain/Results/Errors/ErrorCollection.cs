using System.Collections;

namespace MazyPlatform.SharedKernel.Domain.Results.Errors;

public sealed record class ErrorCollection : IEnumerable<Error>
{
    private readonly IEnumerable<Error> _errors;

    public ErrorCollection(IEnumerable<Error> errors) => _errors = errors?.ToArray() ?? throw new ArgumentNullException(nameof(errors));


    public IEnumerator<Error> GetEnumerator() => _errors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    public static implicit operator ErrorCollection(Error error) => new([error]);
    public static implicit operator ErrorCollection(Error[] errors) => new(errors);
}