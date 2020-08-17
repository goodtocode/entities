using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class Line : DomainModel<ILine>, ILine
    {
        [Key]
        public Guid LineKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
