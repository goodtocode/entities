using Goodtocode.Common.Domain;

namespace Goodtocode.Subjects.Domain;

public interface IBusinessObject : IDomainObject
{
    string BusinessName { get; set; }
    string TaxNumber { get; set; }
}