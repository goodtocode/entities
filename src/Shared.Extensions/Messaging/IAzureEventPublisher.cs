using GoodToCode.Shared.Domain;
using System.Threading.Tasks;

namespace GoodToCode.Shared.Messaging
{
    public interface IAzureEventPublisher<TEntity>
    {
        Task PublishEvent(IDomainEvent<TEntity> eventType);
    }
}