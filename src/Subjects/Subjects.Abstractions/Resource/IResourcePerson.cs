using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourcePerson
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid PersonKey { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ResourceKey { get; set; }
        int ResourcePersonId { get; set; }
        Guid ResourcePersonKey { get; set; }
    }
}