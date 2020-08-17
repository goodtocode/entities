using MediatR;

namespace GoodToCode.Shared.Models
{
    public interface IDomainEvent<T> : INotification
    {
        T Item { get; }
    }
}   