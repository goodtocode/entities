using Goodtocode.Common.Domain;

namespace Goodtocode.Subjects.Domain;

public sealed class BusinessCreatedEvent : IDomainEvent<IBusinessObject>
{
    public IBusinessObject Item { get; }

    public BusinessCreatedEvent(IBusinessObject item)
    {
        Item = item;
    }
}
