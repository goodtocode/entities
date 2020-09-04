﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class DetailType : DomainModel<IDetailType>, IDetailType
    {
        public override Guid RowKey { get { return DetailTypeKey; } protected set { DetailTypeKey = value; } }
        public Guid DetailTypeKey { get; set; }
        public string DetailTypeName { get; set; }
        public string DetailTypeDescription { get; set; }
    }
}
