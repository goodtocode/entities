﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IDetailType
    {
        DateTime CreatedDate { get; set; }
        string DetailTypeDescription { get; set; }
        int DetailTypeId { get; set; }
        Guid DetailTypeKey { get; set; }
        string DetailTypeName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}