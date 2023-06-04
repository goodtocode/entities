using Goodtocode.Subjects.Application;

namespace Goodtocode.Subjects.Integration.Common;

public interface IContextSeeder
{
    Task SeedSampleDataAsync(ISubjectsDbContext context);
}