
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceTimeRecurringEntity : ResourceTimeRecurring, IResourceTimeRecurring
    {
        
        public virtual ResourceEntity ResourceKeyNavigation { get; set; }
    }
}
