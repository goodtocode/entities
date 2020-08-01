using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEntityDetail
    {
        DateTime CreatedDate { get; set; }
        Guid DetailKey { get; set; }
        int EntityDetailId { get; set; }
        Guid EntityDetailKey { get; set; }
        Guid EntityKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}