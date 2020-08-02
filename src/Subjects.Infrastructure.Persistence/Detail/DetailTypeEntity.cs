using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class DetailTypeEntity : DetailType, IDetailType
    {
        public DetailTypeEntity()
        {
            Detail = new HashSet<DetailEntity>();
        }

        public virtual ICollection<DetailEntity> Detail { get; set; }
    }
}
