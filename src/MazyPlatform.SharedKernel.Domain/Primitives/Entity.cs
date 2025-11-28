namespace MazyPlatform.SharedKernel.Domain.Primitives;

/// <summary>
/// Базовый класс для доменных сущностей: предоставляет идентичность и базовую логику сравнения по идентификатору,
/// а также хранение меток времени создания и последнего обновления.
/// </summary>
public abstract class Entity : IEquatable<Entity>
{
    /// <summary>
    /// Уникальный идентификатор сущности.
    /// Обязательное поле, должно быть инициализировано при создании сущности.
    /// </summary>
    /// <value>Значение типа <see cref="Guid"/> — уникальный идентификатор сущности.</value>
    public required Guid Id { get; init; }

    /// <summary>
    /// Временная метка создания сущности.
    /// Обязательное поле, должно быть инициализировано при создании сущности.
    /// </summary>
    /// <value>Значение типа <see cref="DateTimeOffset"/> — время создания сущности.</value>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Временная метка последнего обновления сущности. Имеет значение <c>null</c>, если обновлений не было после создания.
    /// </summary>
    /// <value>Значение типа <see cref="DateTimeOffset"/>? — временная метка последнего обновления или <c>null</c>.</value>
    public DateTimeOffset? UpdatedAt { get; private set; }

    /// <summary>
    /// Определяет, равна ли указанная сущность текущей.
    /// Равенство определяется совпадением типа во время выполнения и значения <see cref="Id"/>.
    /// </summary>
    /// <param name="other">Сущность для сравнения с текущей.</param>
    /// <returns>
    /// Значение типа <see cref="bool"/>: <see langword="true"/>, если объекты представляют один и тот же экземпляр или имеют одинаковый тип и идентификатор; иначе <see langword="false"/>.
    /// </returns>
    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id == other.Id;
    }

    /// <summary>
    /// Возвращает хеш-код сущности, основанный на значении <see cref="Id"/>.
    /// </summary>
    /// <returns>
    /// Значение типа <see cref="int"/> — 32-битный хеш-код, предназначенный для использования в хеш-таблицах.
    /// </returns>
    public override int GetHashCode() => Id.GetHashCode();

    /// <summary>
    /// Определяет, равен ли указанный объект текущей сущности.
    /// </summary>
    /// <param name="obj">Объект для сравнения с текущей сущностью.</param>
    /// <returns>
    /// Значение типа <see cref="bool"/>: <see langword="true"/>, если <paramref name="obj"/> является <see cref="Entity"/> и равен текущей сущности; иначе <see langword="false"/>.
    /// </returns>
    public override bool Equals(object? obj) => obj is Entity entity && Equals(entity);

    /// <summary>
    /// Помечает сущность как обновлённую — устанавливает <see cref="UpdatedAt"/> в текущее время UTC.
    /// Предназначено для вызова в доменной логике при изменении состояния сущности.
    /// </summary>
    protected void MarkAsUpdated() => UpdatedAt = DateTimeOffset.UtcNow;

    /// <summary>
    /// Оператор неравенства для сущностей.
    /// </summary>
    /// <param name="a">Первая сущность для сравнения.</param>
    /// <param name="b">Вторая сущность для сравнения.</param>
    /// <returns>
    /// Значение типа <see cref="bool"/>: <see langword="true"/>, если сущности не равны; иначе <see langword="false"/>.
    /// </returns>
    public static bool operator !=(Entity? a, Entity? b) => (a == b) is false;
   
    /// <summary>
    /// Оператор равенства для сущностей. Использует семантику <see cref="Equals(Entity?)"/>.
    /// </summary>
    /// <param name="a">Первая сущность для сравнения.</param>
    /// <param name="b">Вторая сущность для сравнения.</param>
    /// <returns>
    /// Значение типа <see cref="bool"/>: <see langword="true"/>, если сущности равны; иначе <see langword="false"/>.
    /// </returns>
    public static bool operator ==(Entity? a, Entity? b) => a?.Equals(b) ?? b is null;
}