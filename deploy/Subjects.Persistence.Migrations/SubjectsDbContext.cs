//https://www.syncfusion.com/blogs/post/build-crud-application-with-asp-net-core-entity-framework-visual-studio-2019.aspx

using Microsoft.EntityFrameworkCore;

namespace GoodToCode.Subjects.Infrastructure
{
    public partial class SubjectsDbContextDeploy : SubjectsDbContext
    {
        public SubjectsDbContextDeploy()
             : base(new DbContextOptionsBuilder<SubjectsDbContext>().Options)
        {
        }
    }
}
