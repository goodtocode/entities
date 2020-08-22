using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Occurrences.Infrastructure
{
    public partial class OccurrencesDbContextDeploy : OccurrencesDbContext
    {
        public OccurrencesDbContextDeploy()
            : base(new DbContextOptionsBuilder<OccurrencesDbContext>().Options) { }
    }
}
