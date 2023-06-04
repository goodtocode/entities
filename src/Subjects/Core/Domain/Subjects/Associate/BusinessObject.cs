using Goodtocode.Library.Ddd;

namespace Goodtocode.Subjects.Domain;

public class BusinessObject : IDomainObject, IBusinessObject
{
    public string BusinessName { get; set; } = String.Empty;
    public string TaxNumber { get; set; } = String.Empty;
}
