using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GoodToCode.Shared.Models
{
    public abstract class DomainModel<TModel> : IDomainModel<TModel>
    {
        private readonly List<IDomainEvent<TModel>> _domainEvents = new List<IDomainEvent<TModel>>();

        [Key]
        public abstract Guid RowKey { get; set; }
        [IgnoreDataMember]
        public abstract string PartitionKey { get; set; }        
        [IgnoreDataMember]
        public IReadOnlyList<IDomainEvent<TModel>> DomainEvents => _domainEvents;        

        protected DomainModel()
        {
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

            if (RowKey == Guid.Empty || other.RowKey == Guid.Empty)
                return false;

            return RowKey == other.RowKey;
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
            return (GetType().ToString() + RowKey).GetHashCode();
        }
    }
}
