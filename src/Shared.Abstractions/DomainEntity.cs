using GoodToCode.Shared.Messaging;
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public abstract class DomainEntity<TEntity>
    {
        private readonly List<IDomainEvent<TEntity>> _domainEvents = new List<IDomainEvent<TEntity>>();
        public IReadOnlyList<IDomainEvent<TEntity>> DomainEvents => _domainEvents;

        public Guid Key { get; }

        protected DomainEntity()
        {
        }

        protected DomainEntity(Guid key)
            : this()
        {
            Key = key;
        }

        protected void RaiseDomainEvent(IDomainEvent<TEntity> domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DomainEntity<TEntity> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Key == Guid.Empty || other.Key == Guid.Empty)
                return false;

            return Key == other.Key;
        }

        public static bool operator ==(DomainEntity<TEntity> a, DomainEntity<TEntity> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(DomainEntity<TEntity> a, DomainEntity<TEntity> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Key).GetHashCode();
        }

        private Type GetRealType()
        {
            Type type = GetType();

            if (type.ToString().Contains("Aacn.Exams"))
                return type.BaseType;

            return type;
        }
    }
}
