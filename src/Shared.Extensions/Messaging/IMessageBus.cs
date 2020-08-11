using GoodToCode.Shared.Domain;

namespace GoodToCode.Shared.Messaging
{
    public interface IMessageBus<TEntity>
    {
        void SendExamUpdatedInfoMessage(IDomainEvent<TEntity> domainEvent);
    }
}
