﻿using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Person = new HashSet<Person>();
        }

        public int GenderId { get; set; }
        public Guid GenderKey { get; set; }
        public string GenderName { get; set; }
        public string GenderCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}