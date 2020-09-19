using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventAssociateOption : DomainModel<IEventAssociateOption>, IEventAssociateOption
    {
        public override Guid RowKey { get { return EventAssociateOptionKey; } set { EventAssociateOptionKey = value; } }
        public Guid EventAssociateOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid EventKey { get; set; }        
    }
}
