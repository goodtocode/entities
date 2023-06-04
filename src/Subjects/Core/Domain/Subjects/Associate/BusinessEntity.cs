using Goodtocode.Library.Ddd;

namespace Goodtocode.Subjects.Domain;

public class BusinessEntity : DomainEntity<IBusinessObject>, IBusinessEntity
{
    public override string PartitionKey { get; set; } = "Default";
    public override Guid RowKey { get { return BusinessKey; } set { BusinessKey = value; } }
    public Guid BusinessKey { get; set; }
    public string BusinessName { get; set; } = String.Empty;
    public string TaxNumber { get; set; } = String.Empty;
}
