using Goodtocode.Subjects.Application.Common.Mappings;
using AutoMapper;

namespace Goodtocode.Subjects.Unit;

public class TestBase
{
    protected string _def = string.Empty;

    public string Live = "Live";

    public Guid NTI2023EventKey = Guid.Parse("0DACD6A5-4B51-4872-ADC9-9D8CAAA21A35");

    public string Virtual = "Virtual";

    public TestBase()
    {
        Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); })
            .CreateMapper();
    }

    public IMapper Mapper { get; }
}