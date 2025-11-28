namespace MazyPlatform.SharedKernel.Application.Abstraction.Queries;

/// <summary>
/// Представляет запрос (CQS), возвращающий ответ типа <typeparamref name="TResponse"/>.
/// Запросы предназначены для получения данных и не должны изменять состояние приложения.
/// Этот интерфейс служит маркером для соответствующих обработчиков запросов.
/// </summary>
/// <typeparam name="TResponse">Тип возвращаемого ответа запроса.</typeparam>
public interface IQuery<TResponse> { }