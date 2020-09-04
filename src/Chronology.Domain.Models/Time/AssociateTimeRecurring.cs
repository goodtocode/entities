﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class AssociateTimeRecurring : DomainModel<IAssociateTimeRecurring>, IAssociateTimeRecurring
    {
        public override Guid RowKey { get { return AssociateTimeRecurringKey; } protected set { AssociateTimeRecurringKey = value; } }
        public Guid AssociateTimeRecurringKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        
        
    }
}
