namespace Auth.Domain.Abstractions;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected Entity(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }
}
