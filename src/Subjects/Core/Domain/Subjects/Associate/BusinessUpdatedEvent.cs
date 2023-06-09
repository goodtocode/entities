using Goodtocode.Common.Domain;

namespace Goodtocode.Subjects.Domain;

public sealed class BusinessUpdatedEvent : IDomainEvent<IBusinessObject>
{
    public IBusinessObject Item { get; }

    public BusinessUpdatedEvent(IBusinessObject item)
    {
        Item = item;
    }
}
