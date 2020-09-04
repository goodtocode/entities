﻿using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventLocation : DomainModel<IEventLocation>, IEventLocation
    {
        public override Guid RowKey { get { return EventLocationKey; } protected set { EventLocationKey = value; } }
        public Guid EventLocationKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
