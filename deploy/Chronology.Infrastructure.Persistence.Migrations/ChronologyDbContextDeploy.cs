using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Chronology.Infrastructure
{
    public partial class ChronologyDbContextDeploy : ChronologyDbContext
    {
        public ChronologyDbContextDeploy() 
            : base(new DbContextOptionsBuilder<ChronologyDbContext>().Options) { }
    }
}
