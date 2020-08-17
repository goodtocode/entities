using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventLocation : IDomainModel<IEventLocation>
    {
        Guid EventKey { get; set; }
        Guid EventLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
    }
}