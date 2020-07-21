using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IGender
    {
        DateTime CreatedDate { get; set; }
        string GenderCode { get; set; }
        int GenderId { get; set; }
        Guid GenderKey { get; set; }
        string GenderName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}