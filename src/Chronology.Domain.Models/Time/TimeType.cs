﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeType : DomainModel<ITimeType>, ITimeType
    {
        [Key]
        public Guid TimeTypeKey { get; set; }
        public string TimeTypeName { get; set; }
        public string TimeTypeDescription { get; set; }
        public int TimeBehavior { get; set; }
    }
}
