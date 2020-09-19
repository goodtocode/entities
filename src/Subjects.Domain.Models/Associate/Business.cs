using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Business : DomainModel<IBusiness>, IBusiness
    {
        public override Guid RowKey { get { return BusinessKey; } set { BusinessKey = value; } }
        public Guid BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string TaxNumber { get; set; }
    }
}
