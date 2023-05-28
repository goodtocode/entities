using Goodtocode.Library.Ddd;

namespace Goodtocode.Subjects.Domain;

public sealed class BusinessDeletedEvent : IDomainEvent<IBusinessObject>
{
    public IBusinessObject Item { get; }

    public BusinessDeletedEvent(IBusinessObject item)
    {
        Item = item;
    }
}
