using GoodToCode.Shared.Models;
using System.Threading.Tasks;

namespace GoodToCode.Shared.Messaging
{
    public interface IAzureEventPublisher<TEntity>
    {
        Task PublishEvent(IDomainEvent<TEntity> eventType);
    }
}