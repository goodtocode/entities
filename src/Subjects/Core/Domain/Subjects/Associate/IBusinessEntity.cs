using Goodtocode.Common.Domain;

namespace Goodtocode.Subjects.Domain;

public interface IBusinessEntity : IBusinessObject
{
    Guid BusinessKey { get; set; }
}