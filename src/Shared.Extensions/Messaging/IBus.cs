using GoodToCode.Shared.Models;

namespace GoodToCode.Shared.Messaging
{
    public interface IBus<TEntity>
    {
        void Send(IDomainEvent<TEntity> message);
    }
}
