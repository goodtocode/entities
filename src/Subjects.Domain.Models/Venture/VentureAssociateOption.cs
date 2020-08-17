﻿using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureAssociateOption : DomainModel<IVentureAssociateOption>, IVentureAssociateOption
    {
        [Key]
        public Guid VentureAssociateOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AssociateKey { get; set; }
        
        
    }
}