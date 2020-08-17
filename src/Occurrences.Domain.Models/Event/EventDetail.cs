using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventDetail : DomainModel<IEventDetail>, IEventDetail
    {
        [Key]
        public Guid EventDetailKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid DetailKey { get; set; }
    }
}
