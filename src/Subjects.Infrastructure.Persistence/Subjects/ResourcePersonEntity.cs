
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourcePersonEntity : ResourcePerson, IResourcePerson
    {
        public virtual PersonEntity PersonKeyNavigation { get; set; }
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual ResourceEntity ResourceKeyNavigation { get; set; }
    }
}
