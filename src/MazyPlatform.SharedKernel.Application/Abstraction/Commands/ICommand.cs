namespace MazyPlatform.SharedKernel.Application.Abstraction.Commands;

/// <summary>
/// Представляет команду (CQS) без возвращаемого значения.
/// Команды используются для выполнения операций, изменяющих состояние приложения и не предполагающих возврат результата.
/// Этот интерфейс служит маркером для соответствующих обработчиков команд.
/// </summary>
public interface ICommand { }

/// <summary>
/// Представляет команду (CQS), возвращающую ответ типа <typeparamref name="TResponse"/>.
/// Команда инкапсулирует выполнение операции, которая при успешном завершении возвращает значение указанного типа.
/// </summary>
/// <typeparam name="TResponse">Тип возвращаемого ответа команды. Значение не должно быть <c>null</c>.</typeparam>
public interface ICommand<TResponse> where TResponse : notnull { }