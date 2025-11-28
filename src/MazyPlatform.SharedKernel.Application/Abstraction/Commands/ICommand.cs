namespace MazyPlatform.SharedKernel.Application.Abstraction.Commands;

public interface ICommand { }

public interface ICommand<TResponse> where TResponse : notnull { }