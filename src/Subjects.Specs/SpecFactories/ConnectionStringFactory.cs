using Microsoft.Extensions.Configuration;

namespace GoodToCode.Subjects.Specs
{
    public class ConnectionStringFactory
    {
        public string Create()
        {
            return new ConfigurationFactory().Create().GetConnectionString("DefaultConnection");
        }
    }
}
