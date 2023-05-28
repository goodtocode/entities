﻿using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventSchedule : DomainEntity<IEventSchedule>, IEventSchedule
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventScheduleKey; } set { EventScheduleKey = value; } }
        public Guid EventScheduleKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
    }
}
