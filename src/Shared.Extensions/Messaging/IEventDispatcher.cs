using GoodToCode.Shared.Models;
using System.Collections.Generic;

namespace GoodToCode.Shared.Messaging
{
    public interface IEventDispatcher<TEntity>
    {
        void Dispatch(IEnumerable<IDomainEvent<TEntity>> events);
    }
}
