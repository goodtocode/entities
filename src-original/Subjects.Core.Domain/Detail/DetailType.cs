﻿using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class DetailType : DomainEntity<IDetailType>, IDetailType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return DetailTypeKey; } set { DetailTypeKey = value; } }
        public Guid DetailTypeKey { get; set; }
        public string DetailTypeName { get; set; }
        public string DetailTypeDescription { get; set; }
    }
}
