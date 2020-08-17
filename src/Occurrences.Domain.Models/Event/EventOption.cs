using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventOption : DomainModel<IEventOption>, IEventOption
    {
        [Key]
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
