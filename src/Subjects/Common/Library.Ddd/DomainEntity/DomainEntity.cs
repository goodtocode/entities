using Goodtocode.Library.Ddd;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Goodtocode.Library.Ddd;

public abstract class DomainEntity<TModel> : IDomainEntity<TModel> where TModel : IDomainObject
{
    private readonly List<IDomainEvent<TModel>> _domainEvents = new();

    [Key]
    public abstract Guid RowKey { get; set; }
    [IgnoreDataMember]
    public abstract string PartitionKey { get; set; }
    [IgnoreDataMember]
    public IReadOnlyList<IDomainEvent<TModel>> DomainEvents => _domainEvents;

    protected DomainEntity()
    {
    }

    protected DomainEntity(Guid key)
        : this()
    {
        Key = key;
    }


    public Guid Key { get; }

    public void RaiseDomainEvent(IDomainEvent<TModel> domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not DomainEntity<TModel> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetRealType() != other.GetRealType())
            return false;

        if (Key == Guid.Empty || other.Key == Guid.Empty)
            return false;

        return Key == other.Key;
    }

    public static bool operator ==(DomainEntity<TModel>? a, DomainEntity<TModel>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(DomainEntity<TModel>? a, DomainEntity<TModel>? b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetRealType().ToString() + Key).GetHashCode();
    }

    private Type GetRealType()
    {
        var type = GetType();

        if (type.ToString().Contains("Goodtocode.Subjects"))
            return type.BaseType ?? type.GetType();

        return type;
    }
}