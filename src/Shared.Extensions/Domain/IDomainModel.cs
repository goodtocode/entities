﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IDomainModel<TModel>
    {
        Guid Key { get; }
        bool Equals(object obj);
        int GetHashCode();
        void RaiseDomainEvent(IDomainEvent<TModel> domainEvent);
        void ClearDomainEvents();
    }
}