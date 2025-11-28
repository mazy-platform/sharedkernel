namespace MazyPlatform.SharedKernel.Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public required Guid Id { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }

    public DateTimeOffset? UpdatedAt { get; private set; }

    public bool Equals(Entity? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object? obj) => obj is Entity entity && Equals(entity);

    protected void MarkAsUpdated() => UpdatedAt = DateTimeOffset.UtcNow;

    public static bool operator !=(Entity? a, Entity? b) => (a == b) is false;

    public static bool operator ==(Entity? a, Entity? b) => a?.Equals(b) ?? b is null;
}