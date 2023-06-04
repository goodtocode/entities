﻿using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourcePerson : DomainEntity<IResourcePerson>, IResourcePerson
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ResourcePersonKey; } set { ResourcePersonKey = value; } }
        public Guid ResourcePersonKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid PersonKey { get; set; }
        
        
    }
}
