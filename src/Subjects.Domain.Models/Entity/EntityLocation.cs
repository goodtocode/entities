﻿using System;

namespace GoodToCode.Subjects.Models
{
    public class EntityLocation : IEntityLocation
    {
        public int EntityLocationId { get; set; }
        public Guid EntityLocationKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}