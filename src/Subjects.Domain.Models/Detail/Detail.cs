using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Detail : DomainModel<IDetail>, IDetail
    {
        [Key]
        public Guid DetailKey { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailData { get; set; }
    }
}
