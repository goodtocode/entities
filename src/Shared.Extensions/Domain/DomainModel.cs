using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public abstract class DomainModel<TModel> : IDomainModel<TModel>
    {
        private readonly List<IDomainEvent<TModel>> _domainEvents = new List<IDomainEvent<TModel>>();
        public IReadOnlyList<IDomainEvent<TModel>> DomainEvents => _domainEvents;

        public Guid Key { get; }

        protected DomainModel()
        {
        }

        protected DomainModel(Guid key)
            : this()
        {
            Key = key;
        }

        public void RaiseDomainEvent(IDomainEvent<TModel> domainEvent)
        {            
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is DomainModel<TModel> other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            if (Key == Guid.Empty || other.Key == Guid.Empty)
                return false;

            return Key == other.Key;
        }

        public static bool operator ==(DomainModel<TModel> a, DomainModel<TModel> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(DomainModel<TModel> a, DomainModel<TModel> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Key).GetHashCode();
        }
    }
}
