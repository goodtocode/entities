using MediatR;

namespace GoodToCode.Shared.Domain
{
    public interface IDomainEvent<T> : INotification
    {
        T Item { get; }
    }
}   