using Goodtocode.Library.Ddd;

namespace Goodtocode.Subjects.Domain;

public interface IBusinessEntity : IBusinessObject
{
    Guid BusinessKey { get; set; }
}