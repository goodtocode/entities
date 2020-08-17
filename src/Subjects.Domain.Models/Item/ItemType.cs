﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemType : DomainModel<IItemType>, IItemType
    {
        [Key]
        public Guid ItemTypeKey { get; set; }
        public Guid ItemGroupKey { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeDescription { get; set; }
    }
}