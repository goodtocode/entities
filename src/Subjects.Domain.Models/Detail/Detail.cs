﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Detail : DomainModel<IDetail>, IDetail
    {
        public override Guid RowKey { get { return DetailKey; } protected set { DetailKey = value; } }
        public Guid DetailKey { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailData { get; set; }
    }
}
