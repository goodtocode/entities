namespace GoodToCode.Shared.Messaging
{
    public interface IDomainEvent<TEntity>
    {
        TEntity Item { get; }
    }
}