using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Locality.Infrastructure
{
    public partial class LocalityDbContextDeploy : LocalityDbContext
    {
        public LocalityDbContextDeploy()
             : base(new DbContextOptionsBuilder<LocalityDbContext>().Options)
        {
        }
    }
}
