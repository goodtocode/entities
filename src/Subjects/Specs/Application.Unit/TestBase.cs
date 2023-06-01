using Goodtocode.Subjects.Application.Common.Mappings;
using AutoMapper;

namespace Goodtocode.Subjects.Unit;

public class TestBase
{
    protected string _def = string.Empty;

    public TestBase()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); })
            .CreateMapper();
    }

    public IMapper Mapper { get; }
}