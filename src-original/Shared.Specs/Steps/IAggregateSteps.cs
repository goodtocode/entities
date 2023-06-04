using GoodToCode.Shared.Domain;
using System.Threading.Tasks;

namespace GoodToCode.Shared.Specs
{
    public interface IAggregateSteps<T> where T : IDomainAggregate<T>
    {
        T Aggregate { get; }
        Task Cleanup();
    }
}
