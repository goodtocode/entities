using Goodtocode.Subjects.Application;
using Goodtocode.Subjects.Domain;

namespace Goodtocode.Subjects.Integration.Common;
internal class ContextSeeder : IContextSeeder
{
    public async Task SeedSampleDataAsync(ISubjectsDbContext context)
    {
        await context.Business.AddRangeAsync(new List<BusinessEntity> {
            new BusinessEntity()
            {
                BusinessKey = new Guid("2016a497-e56c-4be8-8ef6-3dc5ae1699ce"),
                BusinessName = "BusinessInDb",
                TaxNumber = "123-45678"
            },
            new BusinessEntity()
            {
                BusinessKey = new Guid("d1604a05-f883-40f1-803b-8562b5674f1a"),
                BusinessName = "BusinessInDb",
                TaxNumber = "123-45678"
            }
            }
        );

        await context.SaveChangesAsync(CancellationToken.None);
    }
}
